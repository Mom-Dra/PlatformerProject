using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange_Bear : CheckAttackRange
{
    protected override State OnUpdate()
    {
        Vector3 attackPos = CalcuateAttackPos();
        float contextToAttackPosDistance = Vector3.Distance(context.transform.position, attackPos);
        float contextToTargetDistance = Vector3.Distance(context.transform.position, blackboard.targetTransform.position);

        //Debug.Log($"{contextToTargetDistance} ,   {attackDistance}");

        if(contextToTargetDistance <= attackDistance)
        {
            if (contextToAttackPosDistance <= float.Epsilon)
            {
                Vector3 lookPos = blackboard.targetTransform.position;
                lookPos.y = context.transform.position.y;
                context.transform.LookAt(lookPos);

                if (context.animator != null)
                    context.animator.SetBool("IsWalk", false);

                return State.Success;
            }

            return State.Failure;
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

        // °õÀÇ Y ÁÂÇ¥ À¯Áö.
        attackPos.y = context.transform.position.y;

        return attackPos;
    }
}
