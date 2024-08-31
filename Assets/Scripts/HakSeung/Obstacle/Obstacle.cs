using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected int Damage { get; set; } = 1;
    private PlayerControl playerControl;
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        //플레이어에게 데미지를 전달한다.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
        }
    }

    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
}
