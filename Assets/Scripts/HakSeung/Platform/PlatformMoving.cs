using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMoving : Platform
{
    WaitForSeconds WaitForTrable;
    WaitForFixedUpdate WaitForFixedUD;
    [Header("Moving")]
    public Vector3 trablePos; //ÀÌµ¿ À§Ä¡

    private const float trableWatingTime = 2.0f;
    private const float trableSpeed = 0.5f;

    private  IEnumerator OnMoving()
    {
        float ratio = 0f;
        bool increase = true;

        while (true)
        {
            yield return WaitForFixedUD;

            if (increase)
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
    public override IEnumerator GetOnEvent()
    {
        yield break;
    }
    public override IEnumerator GetOutEvent()
    {
        yield break;
    }

    //protected override IEnumerator GetOnEvent()ºù
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
        WaitForFixedUD = new WaitForFixedUpdate();
    }

    private void Start()
    {
        StartCoroutine(OnMoving());
    }

}
