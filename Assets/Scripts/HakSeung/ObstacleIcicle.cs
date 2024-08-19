using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleIcicle : DynamicObstacle
{
    protected override void OnCollisionEnter(Collision collision)
    {
        //�÷��̾�� ������ ����
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform"))
            ActivateState = false;      
    }

    protected override void Awake()
    {
        base.Awake();
        rb.isKinematic = true;
    }

}
