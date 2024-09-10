using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class AttackTargetAction_Bird : ActionNode    
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
