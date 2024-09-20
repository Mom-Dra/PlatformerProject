using UnityEngine;

public class GunController : MonoBehaviour
{
    public float sensitivity; 
    public float minAngle;
    public float maxAngle;
    public int maxBullet;
    public int curBullet;
    public AmmoUI ammo;

    public BulletFireControl Bullet;
    public GameObject gunBody;
    private Camera mainCamera;
    private float screenHeight;
    public float normalizedY;
    private void Start()
    {
        maxBullet = 6;
        curBullet = 0;
        //currentPitch = 0f;
        maxAngle = 30f;
        minAngle = -180f;
        sensitivity = 500f;

        mainCamera = Camera.main; 
        screenHeight = Screen.height;
        ammo = GameObject.Find("AmmoUI").GetComponent<AmmoUI>();
    }
    public void GunCheck()
    {
        if (ammo != null)
        {
            ammo.currentAmmo = curBullet;
            ammo.UpdateAmmo();
        }
        float mouseY = Input.mousePosition.y;
        normalizedY = mouseY / screenHeight;
        float targetPitch = Mathf.Lerp(minAngle, maxAngle, normalizedY);
        Quaternion targetRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, targetPitch);
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
