using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclePool : MonoBehaviour
{
    public GameObject[] ObstacleArr;
    private DynamicObstacle dynamicObstacle;
    float ObstacleSpawnTimer;
    
    
    Rigidbody rb;
    public void ObstacleActivation(GameObject obstacle) 
    {
        obstacle.SetActive(true);
        //rb.isKinematic = true; 야매로 풀었으니까 다시 고치기 
    }

    public void ObstacleDeactivation(GameObject obstacle, float spawnTime, Vector3 setPos, Rigidbody obstacleRb)
    {
        obstacle.SetActive(false);
        rb = obstacleRb;
        //obstacleRb.isKinematic = true; -> 이걸 여기서 하면 인식 후에도 내려가는 문제가있음
        obstacle.transform.position = setPos;
        StartCoroutine(ObstacleRespawn(obstacle, spawnTime));
    }

    IEnumerator ObstacleRespawn(GameObject obstacle, float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        ObstacleActivation(obstacle);
    }
    private void Start()
    {
        ObstacleArr = GameObject.FindGameObjectsWithTag("DynamicObstacle");
    }

    
}
