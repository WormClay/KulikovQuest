using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private string tagEnemy = "Enemy";
    private string tagPlayer = "Player";
    private string tagVC = "VisibleCollider";
    
    public float Speed = 40f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemy))
        {
            Destroy(other.gameObject);
        }
        if (!other.CompareTag(tagPlayer) && !other.CompareTag(tagVC)) 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("BulletScript");
        Destroy(gameObject, 5f);
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed, ForceMode.Impulse);
    }

}
