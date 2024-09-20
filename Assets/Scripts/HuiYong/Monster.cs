using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;

    private BehaviourTreeRunner runner;
    protected Animator animator;

    private bool isDead;

    private void Awake()
    {
        runner = GetComponent<BehaviourTreeRunner>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int val)
    {
        if (isDead) return;

        hp -= val;

        Debug.Log($"{name}: hp: {hp}!");

        if (hp <= 0)
        {
            isDead = true;
            runner.enabled = false;

            animator.SetTrigger("IsDead");

            Dead();

            Destroy(gameObject, 4f);
        }
        else
        {
            animator.SetTrigger("IsHit");
        }
    }

    protected virtual void Dead()
    {

    }
}
