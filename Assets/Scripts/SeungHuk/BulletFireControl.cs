using Player;
using Unity.VisualScripting;
using UnityEngine;

public class BulletFireControl : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public PlayerControl player;
    public GunController gun;
    public AmmoUI ammo;
    public GameObject gunShot;
    public GameObject fireBullet;

    private void Start()
    {
        ammo = GameObject.Find("AmmoUI").GetComponent<AmmoUI>();
    }
    public void FireBullet()
    {
        if (gun.curBullet != 0)
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
                player.Rebound(10f, transform.position);
                //Vector3 direction = transform.forward * 20f; 
                //bulletRb.velocity = direction;
                gunShot.GetComponent<ParticleSystem>().Play();
                fireBullet.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void Reload()
    {
        gun.curBullet = gun.maxBullet;
        ammo.currentAmmo = gun.maxBullet;
        ammo.UpdateAmmo();
        this.GetComponentInParent<AudioSource>().Play();
    }
    //public void OnParticleCollision(GameObject other)
    //{
        //ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().collision.GetSafeCollisionEvents(other, collisionEvents)];

        //other.GetComponent<Rigidbody>().AddForce(0, 100, 0);
        //ContactPoint contactPoint = other.GetComponent<Collision>().contacts[0];
        //Instantiate(blood, contactPoint.point, Quaternion.identity);
    //}
}
