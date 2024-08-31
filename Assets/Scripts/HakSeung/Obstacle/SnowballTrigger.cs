using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballTrigger : MonoBehaviour
{

    public bool isInvisibleBall;
    public Rigidbody snowballRb;
    public ObstacleSnowball snowball;
    [SerializeField]
    private bool isOnTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isOnTrigger)
        {
            isOnTrigger = true; 
            snowballRb.isKinematic = false;
            StartCoroutine(snowball.CheckObstacleIsInCamera());
            StartCoroutine(snowball.CheckSnowballOnPlayerScreen());

            if(isInvisibleBall)
            {
                StartCoroutine( snowball.InvisibleTrap());
            }
        }
    }

    private void Awake()
    {
        snowballRb.isKinematic = true;
    }
}
