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
    const float maxFallYlen = 5.0f;
    const float fallingSpeed = 5.0f;
    const float minRidingTime = 0.1f;

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
        
        isRunToGetOnEvent = true;

        do
        {
            Debug.Log(ridingTime);
            while (isGetOnPlatform)
            {
                Debug.Log("Down");
                yield return WaitForFixedUD;
                if (transform.position.y <= maxFallPos.y) { yield return new WaitUntil(() => !isGetOnPlatform); }

                if (ridingTime > minRidingTime)
                    transform.position = Vector3.MoveTowards(transform.position, maxFallPos, Time.fixedDeltaTime * fallingSpeed);
                else
                    ridingTime += Time.fixedDeltaTime;
            }
            ridingTime = 0;

            while (!isGetOnPlatform )
            {
                Debug.Log("Up");
                yield return WaitForFixedUD;
                if (transform.position.y >= InitPlatformPos.y) { yield return new WaitUntil(() => isGetOnPlatform); }
                
                if(ridingTime > minRidingTime)
                     transform.position = Vector3.MoveTowards(transform.position, InitPlatformPos, Time.fixedDeltaTime * fallingSpeed);
                else
                    ridingTime += Time.fixedDeltaTime;
            }
            ridingTime = 0;

            Debug.Log("DoWhile!");

            yield return WaitForFixedUD;

        } while (isGetOnPlatform);

        Debug.Log("³¡");

        isRunToGetOnEvent = false;
    }

    protected override void Awake()
    {
        base.Awake();
        maxFallPos = new Vector3(InitPlatformPos.x, InitPlatformPos.y - maxFallYlen, InitPlatformPos.z);
        WaitForFixedUD = new WaitForFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGetOnPlatform = true;
            if (!isRunToGetOnEvent)
            {
                ridingTime = 0;
                StartCoroutine(GetOnEvent());

                Debug.Log("Hello WOlrd");

                //collision.transform.parent = transform;
            }
        }
    }

    protected override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            isGetOnPlatform = false;
        }
    }
}
