using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollapsing : Platform
{
    WaitForSeconds WaitForcollapisingTime;

    [SerializeField]
    float collapsingTime = 2.0f;

    protected override IEnumerator GetOnEvent()
    {
        yield return WaitForcollapisingTime;
        PlatformCollider.enabled = false;
        PlatformRb.isKinematic = false;
        PlatformRb.useGravity = true;

        yield return WaitForcollapisingTime;
        PlatformCollider.enabled = true;
        PlatformRb.isKinematic = true;
        PlatformRb.useGravity = false;
        this.transform.position = InitPlatformPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collapsing√Êµπ!");
        StartCoroutine(GetOnEvent());
    }


    protected override void Awake()
    {
        base.Awake();
        WaitForcollapisingTime = new WaitForSeconds(collapsingTime);
    }

}
