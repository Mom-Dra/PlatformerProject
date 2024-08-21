using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class GoToTargetAction : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        // Target을 어디서 설정할까요?
        if (Vector3.Distance(context.transform.position, blackboard.targetTransform.position) > 0.01f)
        {
            context.transform.position = Vector3.MoveTowards(context.transform.position, blackboard.targetTransform.position, blackboard.speed * Time.deltaTime);
            context.transform.LookAt(blackboard.targetTransform.position);
        }

        return State.Success;
    }
}
