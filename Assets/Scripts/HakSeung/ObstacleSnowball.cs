using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSnowball : DynamicObstacle
{
    public Vector3 moveDir;
    Camera mainCamera;
    WaitForSeconds waitDeactivation;

    Vector3 screenPoint;


    float deactiveTime = 5.0f;
    bool onScreen = false;
    bool foundPlayer = false;

    public bool CheckObstacleIsInCamera(GameObject target)
    {
        screenPoint = mainCamera.WorldToViewportPoint(target.transform.position);
        onScreen = screenPoint.y > 0 && screenPoint.x > 0 && 
            screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        
        return onScreen;
    }

    IEnumerator CheckSnowballOnPlayerScreen()
    {
        while (true)
        {
            Debug.Log("ÀÛµ¿ CheckSnowballOnScreen" );
            yield return waitDeactivation;
            if (!onScreen) { obstaclePool.ObstacleDeactivation(this.gameObject); break; }
        }
    }


    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        waitDeactivation = new WaitForSeconds(deactiveTime);
        //SetSpawnTime(spawnTime);
    }

    private void Update()
    {
        //rb.AddForce(Vector3.down * 1000 * Time.deltaTime);
        

        if (CheckObstacleIsInCamera(this.gameObject)) foundPlayer = true;

        if(foundPlayer == true && !onScreen )
        {
            StartCoroutine(CheckSnowballOnPlayerScreen());
            foundPlayer = false;
        }

    }




}
