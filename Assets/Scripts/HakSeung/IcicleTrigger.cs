using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrigger : MonoBehaviour 
{
    public ObstacleIceLance ObstacleIceLance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            ObstacleIceLance.Attack();
        }
    }
}
