using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetAction_Bear : AttackTargetAction
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private GameObject particleGameObjectPrefab;
    private GameObject particleGameObject;
    private ParticleSystem particleSystem;
    private Transform attackPos;
    private PlayerControl playerControl;

    private AudioSource audioSource;

    protected override void OnStart()
    {
        if(particleSystem == null)
        {
            particleGameObject = Instantiate(particleGameObjectPrefab);
            particleSystem = particleGameObject.GetComponent<ParticleSystem>();
            attackPos = context.transform.Find("AttackPos");

            particleSystem.transform.localScale = context.transform.localScale;
            playerControl = blackboard.targetTransform.GetComponent<PlayerControl>();

            audioSource = context.transform.GetComponent<AudioSource>();
        }
    }

    protected override void Attack()
    {
        int randomNum = Random.Range(1, 4);
        context.animator.SetTrigger($"Attack{randomNum}");

        // 공격한 위치에 공격 파티클 시스템 재생!
        particleGameObject.transform.position = attackPos.transform.position;
        particleSystem?.Play();

        playerControl?.hp.TakeDamage(damage);

        audioSource?.Play();
    }
}
