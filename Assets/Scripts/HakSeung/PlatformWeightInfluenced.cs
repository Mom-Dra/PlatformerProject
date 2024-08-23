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
        //Vector3 vectorpos = new Vector3(transform.position.x, transform.position.y - maxFallYpos, transform.position.z);
        while (isGetOnPlatform && !isReachedPos )
        {
            Debug.Log("떨어진다");
            yield return null;
            if (transform.position.y <= InitPlatformPos.y - maxFallYpos) { isReachedPos = true;}
            transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            //transform.position = Vector3.MoveTowards(transform.position, vectorpos, Time.deltaTime);
        }
        
        isReachedPos = false;

        yield return ridingTimeOver;

        while (!isGetOnPlatform && !isReachedPos )
        {
            Debug.Log("올라간다");

            yield return null;
            if (transform.position.y >= InitPlatformPos.y) { isReachedPos = true;}
            transform.Translate(Vector3.up * Time.deltaTime * fallingSpeed);
            //transform.position = Vector3.MoveTowards(transform.position, InitPlatformPos, Time.deltaTime);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            
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
            isGetOnPlatform = false;
            StartCoroutine(RidingTimer());
        }
    }
}
