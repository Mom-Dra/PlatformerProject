using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private int hp = 3;

    private BehaviourTreeRunner runner;
    private Animator animator;

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
        }
        else
        {
            animator.SetTrigger("IsHit");
        }
    }
}
