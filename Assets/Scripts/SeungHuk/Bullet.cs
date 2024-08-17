using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �Ѿ��� �ӵ�
    public float lifetime = 5f; // �Ѿ��� ���� �ð�

    private void Start()
    {
        // �Ѿ��� �߻�� �� ���� �ð��� ������ ����
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // �Ѿ��� ���� �������� �̵�
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}