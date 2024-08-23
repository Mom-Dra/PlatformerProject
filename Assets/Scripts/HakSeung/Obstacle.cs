using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected int Damage { get; set; } = 1;
  
    protected virtual void OnCollisionEnter(Collision collision)
    {
        //플레이어에게 데미지를 전달한다.
        if (collision.gameObject.tag == "Player") Debug.Log("플레이어를 공격했다.");
    }
}
