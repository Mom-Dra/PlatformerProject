using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMoving : Platform
{
    WaitForSeconds WaitForTrable;

    [Header("Moving")]
    public Vector3 trablePos; //이동 위치

    private const float trableWatingTime = 2.0f;
    private const float trableSpeed = 0.5f;

    protected override  IEnumerator GetOnEvent()
    {
        float ratio = 0f;
        bool increase = true;

        while (true)
        {
            yield return null;

            if(increase)
            {
                ratio += trableSpeed * Time.deltaTime;
                if (ratio >= 1f) { increase = false; yield return WaitForTrable; } 
            }
            else
            {
                ratio -= trableSpeed * Time.deltaTime;
                if (ratio <= 0f) { increase = true; yield return WaitForTrable; }
            }

            transform.position = Vector3.Lerp(InitPlatformPos, trablePos, ratio);
        }
    }

    //protected override IEnumerator GetOnEvent()
    //{
    //    while (true)
    //    {
    //        yield return null;
            
    //        base.transform.position = Vector3.MoveTowards(base.transform.position, trableTargetPos, Time.deltaTime * trableSpeed);

    //        if (trableTargetPos == InitPlatformPos) { yield return WaitForTrable; trableTargetPos = trablePos; }
    //        if (trableTargetPos == trablePos) { yield return WaitForTrable; trableTargetPos = InitPlatformPos; }

    //    } 
    //}

    protected override void Awake()
    {
        base.Awake();
        WaitForTrable = new WaitForSeconds(trableWatingTime);
    }

    private void Start()
    {
        StartCoroutine(GetOnEvent());
    }
}
