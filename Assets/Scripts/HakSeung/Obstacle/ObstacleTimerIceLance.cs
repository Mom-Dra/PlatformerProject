using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTimerIceLance : ObstacleIceLance
{
    [SerializeField]
    float waitingTime = 5.0f;
    WaitForSeconds waitingRainingTime;

    IEnumerator Raining()
    {
        while (true)
        {

            yield return waitingRainingTime;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        waitingRainingTime = new WaitForSeconds(waitingTime);
    }
}
