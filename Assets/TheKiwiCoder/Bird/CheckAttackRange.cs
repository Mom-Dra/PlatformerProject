using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckAttackRange : ActionNode
{
    public float attackDistance;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        float contextToTargetDistance = Vector3.Distance(context.transform.position, blackboard.targetTransform.position);

        if (contextToTargetDistance <= attackDistance)
        {
            Vector3 lookPos = blackboard.targetTransform.position;
            lookPos.y = context.transform.position.y;
            context.transform.LookAt(lookPos);

            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
