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
            Debug.Log("탐지 길이보다 멀다! Fail!!!!");
            return State.Failure;
        }

        Vector3 attackPos = CalculateAttackPos();

        if (context.animator != null)
            context.animator.SetBool("IsWalk", true);

        // 공격 위치까지 context를 움직인다
        // 공격 위치까지 충분히 가깝다면 Success를 반환한다
        context.transform.position = Vector3.MoveTowards(context.transform.position, attackPos, speed * Time.deltaTime);
        attackPos.y = context.transform.position.y;
        context.transform.LookAt(attackPos);

        if (Vector3.Distance(context.transform.position, attackPos) < float.Epsilon)
        {
            Debug.Log("이동 완료!! Success!!!");

            if (contextToTargetDistance > attackDistance)
            {
                Debug.Log("공격 위치까지 왔지만 사거리가 되지 않음");
                context.animator.SetBool("IsWalk", false);
                return State.Running;
            }

            return State.Success;
        }

        Debug.Log("이동 중이다!! Running!!!");
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
