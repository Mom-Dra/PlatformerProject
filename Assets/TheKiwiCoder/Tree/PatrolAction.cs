using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor.Experimental.GraphView;

public class PatrolAction : ActionNode
{
    private int currentWayPointIndex = 0;
    private Transform transform;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;

    //public PatrolAction(Transform transform, Transform[] wayPoints)
    //{
    //    this.transform = transform;
    //    this.wayPoints = wayPoints;
    //}

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
                
                // Animator 설정!
                // Walking Set Bool True
            }
        }
        else
        {
            Transform wp = blackboard.wayPoints[currentWayPointIndex];

            if(Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                currentWayPointIndex = (currentWayPointIndex + 1) % blackboard.wayPoints.Length;
                // Animator 설정!
                // Walking Set Bool False
            }
            else
            {
                // RigidBody로 못바꿀까?
                transform.position = Vector3.MoveTowards(transform.position, wp.position, blackboard.speed * Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }

        state = State.Running;
        return state;
    }
}
