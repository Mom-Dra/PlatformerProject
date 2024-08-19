using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage = 1;
    PlayerControl player;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerControl>();
            player.TakeDamage(damage);
            // �浹�� ������Ʈ�� �ı�
            Destroy(this.gameObject);
        }
    }
}
