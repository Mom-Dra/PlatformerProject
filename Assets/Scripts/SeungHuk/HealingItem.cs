using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int heal = 1;
    PlayerControl player;
    float turnspeed;
    float highHeight;
    float lowHeight;
    bool upSwitch;
    float upSpeed;
    float endTurn;
    private void Start()
    {
        endTurn = 0;
        upSpeed = 0.001f;
        turnspeed = 300f;
        highHeight = transform.position.y + 0.25f;
        lowHeight = transform.position.y - 0.25f;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerControl>();
            player.Heal(heal);
            // 충돌한 오브젝트를 파괴
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        endTurn += 0.1f;
        if(endTurn == 180)
            endTurn = -180;
        //빙글빙글 도는 움직임
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, endTurn, 0), turnspeed * Time.deltaTime);

        //위아래 움직임
        if(upSwitch)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + upSpeed, transform.position.z);
            if (transform.position.y > highHeight)
            {
                upSwitch = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - upSpeed, transform.position.z);
            if (transform.position.y < lowHeight)
            {
                upSwitch = true;
            }
        }
    }
}
