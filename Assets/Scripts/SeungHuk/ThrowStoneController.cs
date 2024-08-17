using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowStoneController : MonoBehaviour
{
    public GameObject stonePrefab;
    public void Throw(float power, bool isPlayerLeft)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject stone = Instantiate(stonePrefab, pos, transform.rotation);
        Rigidbody stoneRb = stone.GetComponent<Rigidbody>();
        if (isPlayerLeft)
            stoneRb.velocity = (Vector3.left + Vector3.up) * power; // 속도 조정
        else
            stoneRb.velocity = (Vector3.right + Vector3.up) * power;
    }
}
