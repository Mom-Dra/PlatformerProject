using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObstacle : Obstacle
{
    protected ObstaclePool obstaclePool { get; set; }

    protected Rigidbody rb;

    private float spawnTime = 5.0f;
  
    public float GetSpawnTime () { return spawnTime; }
    protected void SetSpawnTime(float spawnTime) { this.spawnTime = spawnTime; }

    Vector3 initPos;
    public Vector3 InitPos { get { return initPos; } }

    protected virtual void Awake()
    {
        initPos = transform.position;
        obstaclePool = FindAnyObjectByType<ObstaclePool>();
        rb = GetComponent<Rigidbody>();        
    }

}
