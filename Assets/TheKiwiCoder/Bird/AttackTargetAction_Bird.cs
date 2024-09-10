    using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class AttackTargetAction_Bird : ActionNode    
{
    [SerializeField]
    private GameObject particleGameObjectPrefab;
    private GameObject particleGameObject;
    private Transform attackTransform;
    private ParticleSystem particleSystem;

    protected override void OnStart()
    {
        if(particleSystem == null)
        {
            particleGameObject = Instantiate(particleGameObjectPrefab);
            particleSystem = particleGameObject.GetComponent<ParticleSystem>();
            attackTransform = context.transform.Find("AttackPos");
        }
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        Attack();

        return State.Success;
    }

    protected virtual void Attack()
    {
        context.animator.SetTrigger("Attack");
        particleGameObject.transform.position = attackTransform.position;

        particleGameObject.transform.LookAt(blackboard.detectedTargetPos);

        particleSystem.Play();
    }
}
