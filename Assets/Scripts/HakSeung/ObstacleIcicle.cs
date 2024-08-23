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
        //��Ȱ��ȭ
        transform.position = initIciclePos;
    }

    public void Falling()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�÷��̾�� ������ ����
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Platform") ;
        //��帧�� ��Ȱ��ȭ �Ѵ�.
            
    }

    private void Awake()
    {
        waitSpawnTime = new WaitForSeconds(spawnTime);
        initIciclePos = transform.position;
    }
}
