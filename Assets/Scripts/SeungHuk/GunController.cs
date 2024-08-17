using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float sensitivity; // 마우스 이동에 대한 민감도
    public float minAngle; // 총의 최소 회전 각도 (위로)
    public float maxAngle;  // 총의 최대 회전 각도 (아래로)
    public int maxBullet; //총알 갯수

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
        maxAngle = -30f;
        minAngle = -150f;
        sensitivity = 500f;

        mainCamera = Camera.main; // 메인 카메라를 가져옵니다.
        screenHeight = Screen.height; // 화면 높이를 저장합니다.
    }
    public void GunCheck()
    { 
        // 마우스의 Y 위치를 가져옵니다.
        float mouseY = Input.mousePosition.y;

        // 마우스의 Y 위치를 0에서 1 사이의 비율로 정규화합니다.
        normalizedY = mouseY / screenHeight;

        // 정규화된 값을 기반으로 총의 피치를 조절합니다.
        float targetPitch = Mathf.Lerp(minAngle, maxAngle, normalizedY);

        // 총의 현재 회전을 계산합니다.
        Quaternion targetRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, targetPitch);

        // 부드러운 이동을 위해 총의 회전을 보간합니다.
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
