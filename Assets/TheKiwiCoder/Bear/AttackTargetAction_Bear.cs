using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetAction_Bear : AttackTargetAction
{
    private GameObject particleGameObejct;
    private ParticleSystem particleSystem;

    protected override void OnStart()
    {
        if(particleGameObejct == null)
        {
            particleGameObejct = Instantiate(blackboard.attackParticle);
            particleSystem = particleGameObejct.GetComponent<ParticleSystem>();
        }
    }

    protected override void Attack()
    {
        int randomNum = Random.Range(1, 4);
        context.animator.SetTrigger($"Attack{randomNum}");

        // ������ ��ġ�� ���� ��ƼŬ �ý��� ���!
        int a;
        float b;

        for(int i = 0; i < 30; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                int nx, ny;


            }
        }
    }
}
