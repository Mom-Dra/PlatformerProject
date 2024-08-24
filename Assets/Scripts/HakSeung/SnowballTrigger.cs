using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballTrigger : MonoBehaviour
{
    public Rigidbody snowballRb;
    public ObstacleSnowball snowball;
    private bool isOnTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isOnTrigger)
        {
            isOnTrigger = true; 
            snowballRb.isKinematic = false;
            StartCoroutine(snowball.CheckObstacleIsInCamera());
            StartCoroutine(snowball.CheckSnowballOnPlayerScreen());
        }
    }

    private void Awake()
    {
        snowballRb.isKinematic = true;
    }
}
