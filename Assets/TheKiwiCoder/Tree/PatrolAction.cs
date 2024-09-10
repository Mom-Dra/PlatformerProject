using UnityEngine;
using TheKiwiCoder;

public class PatrolAction : ActionNode
{
    //[SerializeField]
    //private Transform[] wayPoints;

    [SerializeField]
    private Vector3[] wayPoints;

    private int currentWayPointIndex = 0;
    private Transform transform;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;

    protected override void OnStart()
    {
        transform = context.transform;
        waiting = false;
        context.animator.SetBool("IsWalk", true);
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
            Vector3 wp = wayPoints[currentWayPointIndex];

            if(Vector3.Distance(transform.position, wp) < 0.01f)
            {
                transform.position = wp;
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
                transform.position = Vector3.MoveTowards(transform.position, wp, blackboard.speed * Time.deltaTime);
                transform.LookAt(wp);
            }
        }

        // Running�� ��ȯ�ϸ� �ȵǴ°ǰ�?
        return State.Success;
    }
}
