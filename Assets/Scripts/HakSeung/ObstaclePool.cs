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
        //rb.isKinematic = true; �߸ŷ� Ǯ�����ϱ� �ٽ� ��ġ�� 
    }

    public void ObstacleDeactivation(GameObject obstacle, float spawnTime, Vector3 setPos, Rigidbody obstacleRb)
    {
        obstacle.SetActive(false);
        rb = obstacleRb;
        //obstacleRb.isKinematic = true; -> �̰� ���⼭ �ϸ� �ν� �Ŀ��� �������� ����������
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
