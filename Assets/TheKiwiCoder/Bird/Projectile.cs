using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(LayerEnum.Player.ToString()))
        {
            Debug.Log($"Projectile Triggered Player");

            other.GetComponent<PlayerControl>().hp.TakeDamage(damage);
        }
    }
}
