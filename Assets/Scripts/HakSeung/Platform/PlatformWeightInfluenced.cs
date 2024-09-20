using System.Collections;
using UnityEngine;

public class PlatformWeightInfluenced : Platform
{
    WaitUntil ridingTimeOver;
    WaitForFixedUpdate WaitForFixedUD;
    

    [Header("WeightInflueneced")]
    public float maxFallYlen = 5.0f;
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

    public override IEnumerator GetOnEvent()
    {

        isGetOnPlatform = true;

        if (isRunToGetOnEvent) yield break;

        ridingTime = 0;

        isRunToGetOnEvent = true;

        do
        {
            while (isGetOnPlatform )
            {
                yield return WaitForFixedUD;
                if (transform.position.y <= maxFallPos.y) { yield return new WaitUntil(() => !isGetOnPlatform); }

                if (ridingTime > minRidingTime)
                    transform.position = Vector3.MoveTowards(transform.position, maxFallPos, Time.fixedDeltaTime * fallingSpeed);
                else
                    ridingTime += Time.fixedDeltaTime;

               
            }

            ridingTime = 0;

            while (!isGetOnPlatform)
            {
                yield return WaitForFixedUD;
                if (transform.position.y >= InitPlatformPos.y) { break; }

                if (ridingTime > minRidingTime)
                    transform.position = Vector3.MoveTowards(transform.position, InitPlatformPos, Time.fixedDeltaTime * fallingSpeed);
                else
                    ridingTime += Time.fixedDeltaTime;
                
            }

            ridingTime = 0;

            Debug.Log(ridingTime);
            yield return WaitForFixedUD;

        } while (transform.position != InitPlatformPos);


        isRunToGetOnEvent = false;
    }

    public override IEnumerator GetOutEvent()
    {
        if (isRunToGetOnEvent)
            isGetOnPlatform = false;

        yield break;
    }
    protected override void Awake()
    {
        base.Awake();
        maxFallPos = new Vector3(InitPlatformPos.x, InitPlatformPos.y - maxFallYlen, InitPlatformPos.z);
        WaitForFixedUD = new WaitForFixedUpdate();
    }

/*    private void OnCollisionEnter(Collision collision)
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
    }*/

/*    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if(isRunToGetOnEvent)
                isGetOnPlatform = false;
        }
    }*/
}
