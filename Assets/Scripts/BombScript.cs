using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private string tagEnemy = "Enemy";
    private string tagPlayer = "Player";
    public float Speed = 3f;
    private AudioSource audioSource;
    public PlayerObjects playerObjects { private get; set; }
    private bool isDead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemy) && !isDead)
        {
            isDead = true;
            audioSource.Play();
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
