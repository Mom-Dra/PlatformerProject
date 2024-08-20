using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSnowball : DynamicObstacle
{
    Camera mainCamera;
    WaitForSeconds waitDeactivation;

    Vector3 screenPoint;

    float deactiveTime = 3.0f;
    //float spawnTime = 5.0f;
    bool onScreen = false;
    bool isOnSnowballCheck = false;

    public bool CheckObstacleIsInCamera(GameObject target)
    {
        screenPoint = mainCamera.WorldToViewportPoint(target.transform.position);
        onScreen = screenPoint.y > 0 && screenPoint.x > 0 && 
            screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        
        return onScreen;
    }

    IEnumerator DeactivationTimer()
    {
        Debug.Log("¿€µø DeactivationTimer");
        yield return waitDeactivation;
        obstaclePool.ObstacleDeactivation(this.gameObject);
    }

    IEnumerable CheckSnowballOnScreen()
    {
        yield return null;
        while (true)
        {
            Debug.Log("¿€µø CheckSnowballOnScreen" );
            if (!onScreen) { DeactivationTimer(); break; }
        }
    }


    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        waitDeactivation = new WaitForSeconds(deactiveTime);
        SetSpawnTime(spawnTime);
    }

    private void Update()
    {
        CheckObstacleIsInCamera(this.gameObject);

        if (onScreen && !isOnSnowballCheck){CheckSnowballOnScreen();}
        if (onScreen) { isOnSnowballCheck = true; }
    
       //ø©±‚º≠ ∏ÿ√„

    }




}
