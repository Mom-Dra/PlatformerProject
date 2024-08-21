using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RushAction : ActionNode
{
    public float rushSpeed;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (Vector3.Distance(context.transform.position, blackboard.detectedTargetPos) > 0.01f)
        {
            context.transform.position = Vector3.MoveTowards(context.transform.position, blackboard.detectedTargetPos, rushSpeed * Time.deltaTime);
            context.transform.LookAt(blackboard.detectedTargetPos);

            return State.Running;
        }

        return State.Success;
    }
}
