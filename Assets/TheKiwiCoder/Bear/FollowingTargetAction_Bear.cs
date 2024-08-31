using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowingTargetAction_Bear : FollowingTargetAction
{
    protected override Vector3 CalculateAttackPos()
    {
        Debug.Log("��� ��");
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        attackPos = direction.normalized * (attackDistance - 1) + blackboard.targetTransform.position;

        // ���� Y ��ǥ ����.
        attackPos.y = context.transform.position.y;

        return attackPos;
    }
}
