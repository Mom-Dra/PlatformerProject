using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleIcicle : Obstacle
{
    float spawnTime = 5.0f;
    Vector3 initIciclePos;
    WaitForSeconds waitSpawnTime;

    IEnumerator IcicleRespawn()
    {
        yield return waitSpawnTime;
        //재활성화
        transform.position = initIciclePos;
    }

    public void Falling()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //플레이어에게 데미지 전달
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Platform") ;
        //고드름을 비활성화 한다.
            
    }

    private void Awake()
    {
        waitSpawnTime = new WaitForSeconds(spawnTime);
        initIciclePos = transform.position;
    }
}
