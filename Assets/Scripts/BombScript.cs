using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private string tagEnemy = "Enemy";
    private string tagPlayer = "Player";
    public float Speed = 3f;
    private float radius = 3f;
    private float explosionForce = 500f;
    private float zForce = 0.2f;
    private AudioSource audioSource;
    public PlayerObjects playerObjects { private get; set; }
    private bool isDead = false;
    private ParticleSystem system;
    private MeshRenderer render;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemy) && !isDead)
        {
            isDead = true;
            audioSource.Play();
            system.Play();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var hitCollider in hitColliders) 
            {
                
                if (hitCollider.TryGetComponent<Rigidbody>(out Rigidbody hitRigidbody)) 
                {
                    Debug.Log("hitCollider " + hitCollider);
                    hitRigidbody.AddForce((hitRigidbody.position - transform.position + new Vector3(0, zForce, 0)) * explosionForce);
                }
            }
            Destroy(other.gameObject);
            playerObjects.AddFrag();
        }
        if (!other.CompareTag(tagPlayer))
        {
            Invoke("SelfDestroy", 0.3f);
            render.enabled = false;
        }
    }

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);
        audioSource = GetComponent<AudioSource>();
        system = transform.GetComponentInChildren<ParticleSystem>();
        render = GetComponent<MeshRenderer>(); 
    }

    void SelfDestroy() 
    {
        Destroy(gameObject);
    }
}
