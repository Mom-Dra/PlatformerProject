using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpike : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(PlayerName))
        {
            other.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
        }

    }


}
