using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class CheckTargetInFOVRange : ActionNode
{
    public float fovRange;
    public static int maxColider = 10;
    public static Collider[] colliders = new Collider[maxColider];


    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Debug.Log("OnUpdate, Gizmo");

        int detectedCount = Physics.OverlapSphereNonAlloc(context.transform.position, fovRange, colliders, blackboard.targetLayerMask);

        Debug.Log(detectedCount);

        if(detectedCount > 0)
        {
            Debug.Log($"감지된 거{colliders[0].gameObject.name}");

            blackboard.targetTransform = colliders[0].transform;
            blackboard.detectedTargetPos = colliders[0].transform.position;

            // animator Walking True

            return State.Success;
        }
        else
        {
            blackboard.targetTransform = null;
            blackboard.detectedTargetPos = Vector3.zero;

            return State.Failure;
        }
    }

    public override void OnDrawGizmos()
    {
        Debug.Log("OnDrawGizmos");

        // Gizmos로 OverlapSphere의 범위를 시각적으로 그립니다.
        Gizmos.color = Color.red; // 원하는 색상으로 설정합니다.
        Gizmos.DrawWireSphere(context.transform.position, fovRange);
    }
}
