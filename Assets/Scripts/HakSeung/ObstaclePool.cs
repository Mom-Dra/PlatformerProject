using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclePool : MonoBehaviour
{
    public GameObject[] ObstacleArr;
    private DynamicObstacle dynamicObstacle;
    float ObstacleSpawnTimer;
    
    
    public void ObstacleActivation(GameObject obstacle) 
    {
        obstacle.SetActive(true);
    }

    public void ObstacleDeactivation(GameObject obstacle, float spawnTime, Vector3 setPos, Rigidbody obstacleRb)
    {
        obstacle.SetActive(false);
        obstacle.transform.position = setPos;
        StartCoroutine(ObstacleRespawn(obstacle, spawnTime, obstacleRb));
    }

    public void ObstacleDeactivation(GameObject obstacle)
    {
        obstacle.SetActive(false);
    }

    IEnumerator ObstacleRespawn(GameObject obstacle, float spawnTime, Rigidbody obstacleRb)
    {
        yield return new WaitForSeconds(spawnTime);
        obstacleRb.isKinematic = true; //여기서 안하면 활성화 되면 바로 떨어진다.
        ObstacleActivation(obstacle);
    }
    private void Start()
    {
        ObstacleArr = GameObject.FindGameObjectsWithTag("DynamicObstacle");
    }

    
}
