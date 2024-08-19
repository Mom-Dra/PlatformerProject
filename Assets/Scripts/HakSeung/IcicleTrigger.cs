using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrigger : MonoBehaviour 
{
    public Rigidbody icicleRd;

    [SerializeField]
    bool testFild = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("°¨Áö");
        if (other.gameObject.CompareTag("Player")) icicleRd.isKinematic = false;

    }
}
