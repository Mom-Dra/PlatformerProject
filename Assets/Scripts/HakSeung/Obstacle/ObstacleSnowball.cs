using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSnowball : DynamicObstacle
{
    public Vector3 moveDir;
    Camera mainCamera;
    Vector3 screenPoint;
    

    [SerializeField]
    float deactiveTime =5.0f;
    [SerializeField]
    float activetimer = 0;
    [SerializeField]
    bool onScreen = false;
    [SerializeField]
    bool foundPlayer = false;
    [SerializeField]
    float attackSpeed = 100f;
    [SerializeField]
    float waitTime = 1f;
    public IEnumerator CheckObstacleIsInCamera()
    {
        while (activetimer >= 0)
        {
            screenPoint = mainCamera.WorldToViewportPoint(this.transform.position);
            onScreen = screenPoint.y > 0 && screenPoint.x > 0 &&
                screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if(onScreen) foundPlayer = true;
            yield return null;
        }
    }

    public IEnumerator CheckSnowballOnPlayerScreen()
    {
        activetimer = deactiveTime;
        while (true)
        {
            yield return null;
            while (!onScreen && foundPlayer)
            {
                yield return null;
                activetimer -= Time.deltaTime;
                if (activetimer < 0)
                {
                    Debug.Log("ActiveFalseSnowball");
                    obstaclePool.ObstacleDeactivation(this.gameObject);
                    yield break;
                }
            }
            activetimer = deactiveTime;
        }
    }

    public IEnumerator InvisibleTrap()
    {
        yield return new WaitForSeconds(waitTime);
        rb.velocity = Vector3.forward * -1 * attackSpeed;
    }


    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }





}
