using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public Obstacle obstacle;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(obstacle.PlayerName))
        {
            obstacle.OnTriggerEnterEvent();
        }
    }

}
