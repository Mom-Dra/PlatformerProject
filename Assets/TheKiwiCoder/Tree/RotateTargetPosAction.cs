using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RotateTargetPosAction : ActionNode
{
    [SerializeField]
    private float rotationSpeed;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Quaternion currentRotation = context.transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(blackboard.detectedTargetPos - context.transform.position);

        if (Quaternion.Angle(currentRotation, targetRotation) > 0.1f)
        {
            context.transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

            return State.Running;
        }

        return State.Success;
    }
}
