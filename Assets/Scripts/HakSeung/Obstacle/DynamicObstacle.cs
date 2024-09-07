using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObstacle : Obstacle
{
    [Header("DynamicObstacle")]
    public bool isRespawnObstacle;
    public float DeactiveTime { get; protected set; } = 5.0f;
    [SerializeField]
    public float SpawnTime { get; protected set; } = 5.0f;
    protected ObstaclePool obstaclePool { get; set; }

    protected Rigidbody rb;
  
    Vector3 initPos;
    public Vector3 InitPos { get { return initPos; } }

    protected override void Awake()
    {
        base.Awake();
        initPos = transform.position;
        obstaclePool = FindAnyObjectByType<ObstaclePool>();
        rb = GetComponent<Rigidbody>();        
    }

}
