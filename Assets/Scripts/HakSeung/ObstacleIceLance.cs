using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIceLance : Obstacle
{
    public GameObject IceRance;
    public ParticleSystem Icicle;

    public void Attack()
    {
        Icicle.Play();
    }

    
    private void OnParticleCollision(GameObject other)
    {
       
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어를 공격했다.");
        }

        
    }
}
