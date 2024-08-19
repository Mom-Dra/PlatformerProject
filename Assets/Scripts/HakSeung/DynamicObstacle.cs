using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObstacle : Obstacle
{
    //������Ʈ Ȱ�� ��Ȱ�� ����
    public bool ActivateState { get; set; }

    protected Rigidbody rb;

    Vector3 initPos;
    Vector3 InitPos { get { return initPos; } }

    protected virtual void Awake()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();        
    }

}
