using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIceLance : Obstacle
{
    [Header("IceLance")]
    public ParticleSystem iceLance;
    public  AudioSource fallingAudio;
    AudioSource collisionAudio;
    public void OnDrop()
    {
        iceLance.Play();
        fallingAudio.Play();
       // StartCoroutine(DestroyAudioEvent());
    }

   /* IEnumerator DestroyAudioEvent()
    {
        while (iceLance.isPlaying)
        {
            yield return null;
        }

        collisionAudio.Play();
    }*/

    public override void OnTriggerEnterEvent()
    {
        OnDrop();
    }

    private void OnParticleCollision(GameObject other)
    {
        //플레이어에게 데미지를 전달한다.
        if (other.gameObject.CompareTag(PlayerName))
        {
            other.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(1f);
            collisionAudio.Play();
        }
    }



    protected override void Awake()
    {
        base.Awake();
        collisionAudio = GetComponent<AudioSource>();
    }
}
