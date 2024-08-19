using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformWeightInfluenced : Platform
{
    [Header("WeightInflueneced")]
    const float maxFallYpos = 5.0f;
    const float fallingSpeed = 3.0f;
    const float minRidingTime = 0.5f;

    WaitUntil ridingTimeOver;

    [SerializeField]
    float ridingTime;
    [SerializeField]
    bool isGetOnPlatform = false;
    [SerializeField]
    bool isRunToGetOnEvent = false;

    protected override IEnumerator GetOnEvent()
    {
        bool isReachedPos = false;
        isRunToGetOnEvent = true;

        while (isGetOnPlatform && !isReachedPos)
        {
            yield return null;
            if (transform.position.y <= InitPlatformPos.y - maxFallYpos) { isReachedPos = true;}
            transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
        }
        
        isReachedPos = false;

        yield return ridingTimeOver;

        while (!isGetOnPlatform && !isReachedPos )
        {
            yield return null;
            if (transform.position.y >= InitPlatformPos.y) { isReachedPos = true;}
            transform.Translate(Vector3.up * Time.deltaTime * fallingSpeed);
        }   

        isRunToGetOnEvent = false;
    }

    IEnumerator RidingTimer()
    {
        while(!isGetOnPlatform)
        {
            yield return null;
            ridingTime += Time.deltaTime;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        ridingTimeOver = new WaitUntil(() => ridingTime > minRidingTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGetOnPlatform = true;
        if (!isRunToGetOnEvent)
        {
            ridingTime = 0;
            StartCoroutine(GetOnEvent());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGetOnPlatform = false;
        StartCoroutine(RidingTimer());
    }
}
