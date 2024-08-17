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
            // 충돌한 오브젝트를 파괴
            Destroy(this.gameObject);
        }
    }
}
