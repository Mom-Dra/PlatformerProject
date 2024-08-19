using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleIcicle : DynamicObstacle
{

    protected override void OnCollisionEnter(Collision collision)
    {
        //플레이어에게 데미지 전달
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform"))
            obstaclePool.ObstacleDeactivation(this.gameObject, GetSpawnTime(), InitPos, rb);
    }

    protected override void Awake()
    {
        base.Awake();
        SetSpawnTime(3.0f);
    }

}
