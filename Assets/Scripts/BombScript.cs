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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemy) && !isDead)
        {
            isDead = true;
            audioSource.Play();
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
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);
        audioSource = transform.GetComponent<AudioSource>();
    }
}
