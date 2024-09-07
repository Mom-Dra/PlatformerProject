using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclePool : MonoBehaviour
{
    [Header("ObstaclePool")]
    public GameObject[] ObstacleArr;
    private DynamicObstacle dynamicObstacle;
    [SerializeField]
    private string obstacleName = "DynamicObstacle";
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
        obstacleRb.isKinematic = true; //���⼭ ���ϸ� Ȱ��ȭ �Ǹ� �ٷ� ��������.
        ObstacleActivation(obstacle);
    }
    private void Awake()
    {
        ObstacleArr = GameObject.FindGameObjectsWithTag(obstacleName);
    }

    
}
