using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    bool upSwitch;
    float turnspeed;
    float highHeight;
    float lowHeight;
    float upSpeed;
    float endTurn;
    KeyInput player;
    void Start()
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
            player = other.gameObject.GetComponent<KeyInput>();
            player.GunReLoad();
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        endTurn += 0.1f;
        if (endTurn == 180)
            endTurn = -180;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, endTurn, 0), turnspeed * Time.deltaTime);

        if (upSwitch)
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
