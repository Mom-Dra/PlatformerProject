using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; 
    public float lifetime = 5f; 
    public GameObject player;
    public GameObject blood;
    public Vector3 dir;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Guy");
        //this.GetComponentInParent<AudioSource>().Play();
        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        //transform.Translate(Vector3.forward * 1f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Trap")))
        {
            ContactPoint contactPoint = collision.contacts[0];
            GameObject be = Instantiate(blood, contactPoint.point, Quaternion.identity);
            be.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}