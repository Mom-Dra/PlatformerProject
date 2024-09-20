    using JetBrains.Annotations;
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

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip particleSound1;

    [SerializeField]
    private AudioClip particleSound2;

    protected override void OnStart()
    {
        if(particleSystem == null)
        {
            particleGameObject = Instantiate(particleGameObjectPrefab);
            particleSystem = particleGameObject.GetComponent<ParticleSystem>();
            attackTransform = context.transform.Find("AttackPos");
            audioSource = context.transform.GetComponent<AudioSource>();
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

        particleGameObject.transform.LookAt(blackboard.targetTransform.position);
        particleSystem.Play();

        int randomVal = Random.Range(0, 2);

        if(randomVal == 0)
            audioSource.PlayOneShot(particleSound1);
        else
            audioSource.PlayOneShot(particleSound2);

    }
}
