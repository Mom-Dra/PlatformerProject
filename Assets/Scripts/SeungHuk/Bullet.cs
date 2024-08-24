using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; 
    public float lifetime = 5f; 
    public GameObject player;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Guy");
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}