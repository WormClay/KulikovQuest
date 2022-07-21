using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private string tagEnemy = "Enemy";
    private string tagPlayer = "Player";
    private string tagVC = "VisibleCollider";
    public PlayerObjects playerObjects { private get;  set; }

    public float Speed = 40f;
    private bool isDead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemy) && !isDead)
        {
            isDead = true;
            Destroy(other.gameObject);
            playerObjects.AddFrag();
        }
        if (!other.CompareTag(tagPlayer) && !other.CompareTag(tagVC)) 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, 5f);
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);
    }

}
