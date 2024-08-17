using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected int Damage { get; set; } = 1;
  
    protected virtual void OnCollisionEnter(Collision collision)
    {
        //�÷��̾�� �������� �����Ѵ�.
        if (collision.gameObject.tag == "Player") Debug.Log("�÷��̾ �����ߴ�.");
    }
}
