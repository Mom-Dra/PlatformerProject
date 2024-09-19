using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    public string PlayerName { get; private set; } = "Player";
    [SerializeField]
    protected int Damage { get; set; } = 1;
    [SerializeField]
    private PlayerControl playerControl;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerName))
        {
            collision.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
            collision.gameObject.GetComponent<PlayerControl>().Rebound(10f);
           
        }
    }

    public virtual void OnTriggerEnterEvent() { }
    

    protected virtual void Awake()
    {
        playerControl = GameObject.FindGameObjectWithTag(PlayerName).GetComponent<PlayerControl>();
    }
}
