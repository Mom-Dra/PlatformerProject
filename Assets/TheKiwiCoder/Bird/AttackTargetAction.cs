using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class AttackTargetAction : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Attack();

        return State.Success;
    }

    protected virtual void Attack()
    {
        context.animator.SetTrigger("Attack");
    }
}
