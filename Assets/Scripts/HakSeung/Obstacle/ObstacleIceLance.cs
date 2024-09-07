using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIceLance : Obstacle
{
    [Header("IceLance")]
    public ParticleSystem Icicle;
    
    public void OnDrop()
    {
        Icicle.Play();
    }

    public override void OnTriggerEnterEvent()
    {
        OnDrop();
    }

    private void OnParticleCollision(GameObject other)
    {
        //�÷��̾�� �������� �����Ѵ�.
        if (other.gameObject.CompareTag(PlayerName))
        {
            other.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
        }
    }
}
