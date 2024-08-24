using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformWeightInfluenced : Platform
{
    WaitUntil ridingTimeOver;
    WaitForFixedUpdate WaitForFixedUD;
    
    [Header("WeightInflueneced")]
    const float maxFallYpos = 5.0f;
    const float fallingSpeed = 3.0f;
    const float minRidingTime = 0.5f;

    [SerializeField]
    float ridingTime;
    [SerializeField]
    bool isGetOnPlatform = false;
    [SerializeField]
    bool isRunToGetOnEvent = false;
    [SerializeField]
    Vector3 maxFallPos;

    protected override IEnumerator GetOnEvent()
    {
        bool isReachedPos = false;
        isRunToGetOnEvent = true;
        while (isGetOnPlatform && !isReachedPos )
        {
            Debug.Log("Down");
            yield return WaitForFixedUD;
            if (transform.position.y <= InitPlatformPos.y - maxFallYpos) { isReachedPos = true;}
            //transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            transform.position = Vector3.MoveTowards(transform.position, maxFallPos, Time.deltaTime * fallingSpeed);
        }
        
        isReachedPos = false;

        yield return ridingTimeOver;

        while (!isGetOnPlatform && !isReachedPos )
        {
            Debug.Log("Up");

            yield return WaitForFixedUD;
            if (transform.position.y >= InitPlatformPos.y) { isReachedPos = true;}
            //transform.Translate(Vector3.up * Time.deltaTime * fallingSpeed);
            transform.position = Vector3.MoveTowards(transform.position, InitPlatformPos, Time.deltaTime * fallingSpeed);
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
        maxFallPos = new Vector3(InitPlatformPos.x, InitPlatformPos.y - maxFallYpos, InitPlatformPos.z);
        ridingTimeOver = new WaitUntil(() => ridingTime > minRidingTime);
        WaitForFixedUD = new WaitForFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("rideIn");       
            isGetOnPlatform = true;
            if (!isRunToGetOnEvent)
            {
                ridingTime = 0;
                StartCoroutine(GetOnEvent());
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("rideOut");

            isGetOnPlatform = false;
            StartCoroutine(RidingTimer());
        }
    }
}
