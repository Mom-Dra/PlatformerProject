using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMonster : Monster
{
    [SerializeField]
    private float power;

    [SerializeField]
    private float damage;

    private PlayerControl playerControl;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 충돌하면 상대방을 날려준다!
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer(LayerEnum.Player.ToString())))
        {
            Debug.Log($"{transform.name} Collide with Player");

            Vector3 addForce = other.transform.position - transform.position;
            addForce.y = 0f;
            addForce = addForce.normalized;
            addForce.y = power;

            playerControl ??= other.gameObject.GetComponent<PlayerControl>();
            playerControl?.Rebound(power, transform.position);
            playerControl?.hp.TakeDamage(damage);

            audioSource ??= GetComponent<AudioSource>();
            audioSource?.Play();
        }
    }
}
