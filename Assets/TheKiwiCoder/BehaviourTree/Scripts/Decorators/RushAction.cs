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
        Vector3 detectedPos = blackboard.detectedTargetPos;
        detectedPos.y = context.transform.position.y;

        if (Vector3.Distance(context.transform.position, detectedPos) > 0.01f)
        {
            context.transform.position = Vector3.MoveTowards(context.transform.position, detectedPos, rushSpeed * Time.deltaTime);
            context.transform.LookAt(detectedPos);

            return State.Running;
        }

        return State.Success;
    }
}
