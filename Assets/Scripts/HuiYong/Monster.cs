using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private int hp = 3;

    BehaviourTreeRunner runner;

    private void Awake()
    {
        runner = GetComponent<BehaviourTreeRunner>();
    }

    public void TakeDamage(int val)
    {
        hp -= val;

        if(hp <= 0)
        {
            runner.enabled = false;
        }
        else
        {
            // 피격 에니메이션!


        }
    }
}
