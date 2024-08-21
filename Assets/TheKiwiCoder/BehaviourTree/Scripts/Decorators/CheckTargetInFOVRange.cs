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
            Debug.Log($"������ ��{colliders[0].gameObject.name}");

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

        // Gizmos�� OverlapSphere�� ������ �ð������� �׸��ϴ�.
        Gizmos.color = Color.red; // ���ϴ� �������� �����մϴ�.
        Gizmos.DrawWireSphere(context.transform.position, fovRange);
    }
}
