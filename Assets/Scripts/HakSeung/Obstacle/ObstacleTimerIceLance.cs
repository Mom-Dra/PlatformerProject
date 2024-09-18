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
        yield return waitingRainingTime;
        //OnDrop();
        iceLance.Play();
    }

    private void OnParticleSystemStopped()
    {
        StartCoroutine(Raining());
    }

    protected override void Awake()
    {
        base.Awake();
        waitingRainingTime = new WaitForSeconds(waitingTime);
    }

    private void Start()
    {
        StartCoroutine(Raining());
    }

}
