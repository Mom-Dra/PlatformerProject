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
            Debug.Log("탐지 길이보다 멀다! 실패!!!!");
            return State.Failure;
        }

        // y좌표: AttackDistance x Sin(60도)
        Vector3 attackPos;
        Vector3 direction = (context.transform.position - blackboard.targetTransform.position);
        direction.y = 0f;
        direction = direction.normalized;
        direction.y = Mathf.Sin(Mathf.Deg2Rad * 60f);
        attackPos = direction.normalized * attackDistance + blackboard.targetTransform.position;

        // 공격 위치까지 context를 움직인다
        // 공격 위치까지 충분히 가깝다면 Success를 반환한다
        context.transform.position = Vector3.MoveTowards(context.transform.position, attackPos, speed * Time.deltaTime);
        context.transform.LookAt(attackPos);

        if(Vector3.Distance(context.transform.position, attackPos) < float.Epsilon)
        {
            Debug.Log("이동 중이다!! 성공!!!");
            return State.Success;
        }

        Debug.Log("이동 중이다!! Running!!!");
        return State.Running;
    }
}
