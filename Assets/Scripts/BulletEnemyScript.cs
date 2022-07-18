using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    [SerializeField] private int damage = 10;

    /*private void OnCollisionEnter(Collision collision)
    {
        Hit(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Hit(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        Hit(collision.gameObject);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject);
    }

    /*private void OnTriggerExit(Collider other)
    {
        Hit(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Hit(other.gameObject);
    }*/

    void Hit(GameObject collisionGO) 
    {
        //Debug.Log($"OnCollisionEnter {collisionGO.name}");
        Destroy(gameObject);
        if (collisionGO.TryGetComponent(out PlayerObjects helth)) 
        {
            helth.Hit(damage);
            Debug.Log($"damage = {damage}");
        }
    }

    void Start()
    {
        Destroy(gameObject, 5f);
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

}
