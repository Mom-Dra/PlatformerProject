using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange_Bear : CheckAttackRange
{
    protected override State OnUpdate()
    {
        Vector3 attackPos = CalcuateAttackPos();
        float contextToAttackPosDistance = Vector3.Distance(context.transform.position, attackPos);

        if (contextToAttackPosDistance <= float.Epsilon)
        {
            Debug.Log("Here We Go!");

            Vector3 lookPos = blackboard.targetTransform.position;
            lookPos.y = context.transform.position.y;
            context.transform.LookAt(lookPos);

            if (context.animator != null)
                context.animator.SetBool("IsWalk", false);

            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }

    protected Vector3 CalcuateAttackPos()
    {
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        attackPos = direction.normalized * attackDistance + blackboard.targetTransform.position;

        // ���� Y ��ǥ ����.
        attackPos.y = context.transform.position.y;

        return attackPos;
    }
}
