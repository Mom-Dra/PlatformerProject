using UnityEngine;
using TheKiwiCoder;

public class CheckTargetInFOVRange : ActionNode
{
    public float fovRange;
    public const int maxColider = 10;
    public Collider[] colliders = new Collider[maxColider];


    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        int detectedCount = Physics.OverlapSphereNonAlloc(context.transform.position, fovRange, colliders, blackboard.targetLayerMask);

        if(detectedCount > 0)
        {
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
