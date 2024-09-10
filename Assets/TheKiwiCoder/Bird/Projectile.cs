using JetBrains.Annotations;
using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"OnParticleCollision: {other.name}");

        if(other.layer == LayerMask.NameToLayer(LayerEnum.Player.ToString()))
        {
            other.GetComponent<PlayerControl>().hp.TakeDamage(damage);
        }
    }
}
