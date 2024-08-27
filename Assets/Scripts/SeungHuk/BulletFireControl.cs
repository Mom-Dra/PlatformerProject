using Player;
using UnityEngine;

public class BulletFireControl : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public PlayerControl player;
    public GunController gun;
    public AmmoUI ammo;

    private void Start()
    {
        ammo = GameObject.Find("AmmoUI").GetComponent<AmmoUI>();
    }
    public void FireBullet()
    {
        if (bulletPrefab && gun.curBullet != 0)
        {
            gun.curBullet--;
            ammo.currentAmmo--;
            ammo.UpdateAmmo();
            Debug.Log("Shot!");
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                player.Rebound(10f);
                Vector3 direction = transform.right * 20f; 
                bulletRb.velocity = direction;

            }
        }
    }
    public void Reload()
    {
        gun.curBullet = gun.maxBullet;
        ammo.currentAmmo = gun.maxBullet;
        ammo.UpdateAmmo();
    }
}
