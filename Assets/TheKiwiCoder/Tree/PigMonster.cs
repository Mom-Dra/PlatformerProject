using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMonster : MonoBehaviour
{
    [SerializeField]
    private float power;

    [SerializeField]
    private float damage;

    private PlayerControl playerControl;

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어 충돌하면 상대방을 날려준다!
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerEnum.Player.ToString()))
        {
            Debug.Log($"{transform.name} Collide with Player");

            Vector3 addForce = collision.transform.position - transform.position;
            addForce.y = 0f;
            addForce = addForce.normalized;
            addForce.y = power;

            if(playerControl == null)
            {
                playerControl = collision.gameObject.GetComponent<PlayerControl>();
            }

            playerControl.Rebound(power);
            playerControl.hp.TakeDamage(damage);
        }
    }
}
