using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrigger : MonoBehaviour
{
    public ObstacleIcicle icicle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") icicle.Falling();
    }

    private void Awake()
    {
        icicle = GetComponent<ObstacleIcicle>();
    }
}
