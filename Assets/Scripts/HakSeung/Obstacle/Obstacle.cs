using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{

    [SerializeField]
    protected int Damage { get; set; } = 1;
    private PlayerControl playerControl;
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
        }
    }

    public virtual void OnTriggerEnterEvent() { }


    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
}
