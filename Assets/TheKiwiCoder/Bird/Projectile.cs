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

    private PlayerControl playerControl;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"OnParticleCollision: {other.name}");

        if(other.layer == LayerMask.NameToLayer(LayerEnum.Player.ToString()))
        {
            if(playerControl == null)
            {
                playerControl = other.GetComponent<PlayerControl>();
            }

            playerControl.hp.TakeDamage(damage);
        }
    }
}
