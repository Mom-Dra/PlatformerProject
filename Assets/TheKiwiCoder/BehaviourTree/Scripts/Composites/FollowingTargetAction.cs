using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FollowingTargetAction : ActionNode
{
    public float distance;

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if(blackboard.targetTransform == null)
        {
            return State.Failure;
        }

        if(Vector3.Distance(context.transform.position, blackboard.targetTransform.position) < distance)
        {


            return State.Running;
        }

        return State.Success;
    }
}
