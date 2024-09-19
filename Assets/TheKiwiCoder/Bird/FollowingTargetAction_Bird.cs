using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTargetAction_Bird : FollowingTargetAction
{
    protected override State OnUpdate()
    {
        float contextToTargetDistance = Vector3.Distance(context.transform.position, blackboard.targetTransform.position);

        if (blackboard.targetTransform == null)
        {
            return State.Failure;
        }
        else if (contextToTargetDistance > detectDistance)
        {
            Debug.Log("Ž�� ���̺��� �ִ�! Fail!!!!");
            return State.Failure;
        }

        Vector3 attackPos = CalculateAttackPos();

        if (context.animator != null)
            context.animator.SetBool("IsWalk", true);

        // ���� ��ġ���� context�� �����δ�
        // ���� ��ġ���� ����� �����ٸ� Success�� ��ȯ�Ѵ�
        context.transform.position = Vector3.MoveTowards(context.transform.position, attackPos, speed * Time.deltaTime);
        attackPos.y = context.transform.position.y;
        context.transform.LookAt(attackPos);

        if (Vector3.Distance(context.transform.position, attackPos) < float.Epsilon)
        {
            Debug.Log("�̵� �Ϸ�!! Success!!!");

            if (contextToTargetDistance > attackDistance)
            {
                Debug.Log("���� ��ġ���� ������ ��Ÿ��� ���� ����");
                context.animator.SetBool("IsWalk", false);
                return State.Running;
            }

            return State.Success;
        }

        Debug.Log("�̵� ���̴�!! Running!!!");
        return State.Running;
    }

    protected override Vector3 CalculateAttackPos()
    {
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        direction = direction.normalized;
        direction.y = Mathf.Sin(Mathf.Deg2Rad * 60f);
        attackPos = direction.normalized * (attackDistance - 1) + blackboard.targetTransform.position;

        return attackPos;
    }
}
