using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMonster : MonoBehaviour
{
    [SerializeField]
    private float power;

    [SerializeField]
    private float damage;

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾� �浹�ϸ� ������ �����ش�!
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerEnum.Player.ToString()))
        {
            Debug.Log($"{transform.name} Collide with Player");

            Vector3 addForce = collision.transform.position - transform.position;
            addForce.y = 0f;
            addForce = addForce.normalized;
            addForce.y = power;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(addForce, ForceMode.Impulse);
            collision.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(damage);
        }
    }
}
