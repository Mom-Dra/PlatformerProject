using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollapsing : Platform
{
    WaitForSeconds WaitForcollapisingTime;

    [Header("Collapsing")]
    [SerializeField]
    float collapsingTime = 2.0f;

    public override IEnumerator GetOnEvent()
    {
        yield return WaitForcollapisingTime;
        PlatformCollider.enabled = false;
        PlatformRb.isKinematic = false;
        PlatformRb.useGravity = true;
        
        yield return WaitForcollapisingTime;
        PlatformCollider.enabled = true;
        PlatformRb.isKinematic = true;
        PlatformRb.useGravity = false;
        transform.position = InitPlatformPos;
    }

    public override IEnumerator GetOutEvent()
    {
        yield break;
    }


    protected override void Awake()
    {
        base.Awake();
        WaitForcollapisingTime = new WaitForSeconds(collapsingTime);
    }

}
