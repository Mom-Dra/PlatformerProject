using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �Ѿ��� �ӵ�
    public float lifetime = 5f; // �Ѿ��� ���� �ð�
    public GameObject player;

    private void Start()
    {
        // �Ѿ��� �߻�� �� ���� �ð��� ������ ����
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Guy");
    }

    private void Update()
    {
        // �Ѿ��� ���� �������� �̵�
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}