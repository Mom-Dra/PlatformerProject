using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 총알의 속도
    public float lifetime = 5f; // 총알의 생명 시간
    public GameObject player;

    private void Start()
    {
        // 총알이 발사된 후 일정 시간이 지나면 삭제
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Guy");
    }

    private void Update()
    {
        // 총알을 현재 방향으로 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}