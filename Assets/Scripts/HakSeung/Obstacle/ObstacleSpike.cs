using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpike : Obstacle
{
    AudioSource OnTriggerAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerName))
        {
            other.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
            other.gameObject.GetComponent<PlayerControl>().Rebound(10f);
            Debug.Log("�۵�");
        }
        Debug.Log("�۵�2");
    }

    protected override void Awake()
    {
        base.Awake();
        OnTriggerAudio = GetComponent<AudioSource>();  
    }

}
