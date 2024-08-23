using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballTrigger : MonoBehaviour
{
    public Rigidbody icicleRd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            icicleRd.isKinematic = false;
        }
    }

    private void Awake()
    {
        icicleRd.isKinematic = true;
    }
}
