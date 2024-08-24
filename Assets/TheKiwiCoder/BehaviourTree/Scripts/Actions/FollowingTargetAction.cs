using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FollowingTargetAction : ActionNode
{
    public float detectDistance;
    public float attackDistance;
    public float speed;

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
            Debug.Log("Ž�� ���̺��� �ִ�! ����!!!!");
            return State.Failure;
        }

        // y��ǥ: AttackDistance x Sin(60��)
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        direction = direction.normalized;
        direction.y = Mathf.Sin(Mathf.Deg2Rad * 60f);
        attackPos = direction.normalized * attackDistance + blackboard.targetTransform.position;

        // ���� ��ġ���� context�� �����δ�
        // ���� ��ġ���� ����� �����ٸ� Success�� ��ȯ�Ѵ�
        context.transform.position = Vector3.MoveTowards(context.transform.position, attackPos, speed * Time.deltaTime);
        context.transform.LookAt(attackPos);

        if(Vector3.Distance(context.transform.position, attackPos) < float.Epsilon)
        {
            Debug.Log("�̵� ���̴�!! ����!!!");
            return State.Success;
        }

        Debug.Log("�̵� ���̴�!! Running!!!");
        return State.Running;
    }
}
