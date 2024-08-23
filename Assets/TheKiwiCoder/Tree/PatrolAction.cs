using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor.Experimental.GraphView;

public class PatrolAction : ActionNode
{
    [SerializeField]
    private Transform[] wayPoints;

    private int currentWayPointIndex = 0;
    private Transform transform;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;

    protected override void OnStart()
    {
        transform = context.transform;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if(waiting)
        {
            waitCounter += Time.deltaTime;
            
            if(waitCounter >= waitTime)
            {
                waiting = false;

                // Animator ����!
                // Walking Set Bool True
                if (context.animator != null)
                {
                    context.animator.SetBool("IsWalk", true);
                }
            }
        }
        else
        {
            Transform wp = wayPoints[currentWayPointIndex];

            if(Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                currentWayPointIndex = (currentWayPointIndex + 1) % wayPoints.Length;
                // Animator ����!
                // Walking Set Bool False

                if (context.animator != null)
                {
                    context.animator.SetBool("IsWalk", false);
                }
            }
            else
            {
                // RigidBody�� ���ٲܱ�?
                transform.position = Vector3.MoveTowards(transform.position, wp.position, blackboard.speed * Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }

        // Running�� ��ȯ�ϸ� �ȵǴ°ǰ�?
        return State.Success;
    }
}
