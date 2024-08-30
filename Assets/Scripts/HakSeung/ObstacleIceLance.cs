using Player;
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

        //�÷��̾�� �������� �����Ѵ�.
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
        }


    }
}
