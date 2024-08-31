using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionEvent : MonoBehaviour
{
    public Platform platform;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(platform.GetOnEvent());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(platform.GetOutEvent());
        }
    }

}
