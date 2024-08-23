using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float sensitivity; // ���콺 �̵��� ���� �ΰ���
    public float minAngle; // ���� �ּ� ȸ�� ���� (����)
    public float maxAngle;  // ���� �ִ� ȸ�� ���� (�Ʒ���)
    public int maxBullet; //�Ѿ� ����

    public BulletFireControl Bullet;
    public GameObject gunBody;
    //private float currentPitch;
    private Camera mainCamera;
    private float screenHeight;
    public float normalizedY;
    private void Start()
    {
        maxBullet = 6;
        //currentPitch = 0f;
        maxAngle = 30f;
        minAngle = -180f;
        sensitivity = 500f;

        mainCamera = Camera.main; // ���� ī�޶� �����ɴϴ�.
        screenHeight = Screen.height; // ȭ�� ���̸� �����մϴ�.
    }
    public void GunCheck()
    { 
        // ���콺�� Y ��ġ�� �����ɴϴ�.
        float mouseY = Input.mousePosition.y;

        // ���콺�� Y ��ġ�� 0���� 1 ������ ������ ����ȭ�մϴ�.
        normalizedY = mouseY / screenHeight;

        // ����ȭ�� ���� ������� ���� ��ġ�� �����մϴ�.
        float targetPitch = Mathf.Lerp(minAngle, maxAngle, normalizedY);

        // ���� ���� ȸ���� ����մϴ�.
        Quaternion targetRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, targetPitch);

        // �ε巯�� �̵��� ���� ���� ȸ���� �����մϴ�.
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * sensitivity);


    }

    public void Reset()
    {
        Bullet.gameObject.SetActive(false);
        gunBody.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Take()
    {
        Bullet.gameObject.SetActive(true);
        gunBody.SetActive(true);
        this.gameObject.SetActive(true);
    }

}
