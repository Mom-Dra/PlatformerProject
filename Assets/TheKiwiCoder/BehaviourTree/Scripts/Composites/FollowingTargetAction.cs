using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FollowingTargetAction : ActionNode
{
    public float detectDistance;
    public float attackDistance;
    public float distance;

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        float contextToTargetDistance = Vector3.Distance(context.transform.position, blackboard.targetTransform.position);

        if (blackboard.targetTransform == null)
        {
            return State.Failure;
        }
        else if(contextToTargetDistance > detectDistance)
        {
            return State.Failure;
        }

        // y��ǥ: AttackDistance x Sin(60��)
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        direction = direction.normalized;
        direction.y = Mathf.Sin(Mathf.Deg2Rad * 60f);
        attackPos = direction.normalized * attackDistance;

        // ���� ��ġ���� context�� �����δ�
        // ���� ��ġ���� ����� �����ٸ� Success�� ��ȯ�Ѵ�

        


        return State.Success;
    }
}
