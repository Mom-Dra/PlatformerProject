using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTargetAction_Bird : FollowingTargetAction
{
    protected override Vector3 CalculateAttackPos()
    {
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        direction = direction.normalized;
        direction.y = Mathf.Sin(Mathf.Deg2Rad * 60f);
        attackPos = direction.normalized * attackDistance + blackboard.targetTransform.position;

        return attackPos;
    }
}
