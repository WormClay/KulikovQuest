using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float speed = 0.0000001f;
    private float time;
    [SerializeField] private bool isRun = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        time = Time.time;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isRun)
        myRigidbody.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
    }


    void OnTriggerEnter(Collider other)
    {
        isRun = false;
        NewDestination();
    }

    void OnTriggerStay(Collider other)
    {
        if (Time.time > (time + 1))
        {
            NewDestination();
            time = Time.time;
        }
    }

    void NewDestination() 
    {
        float aa = Random.Range(1f, 360f);
        transform.eulerAngles = new Vector3(transform.rotation.x, aa, transform.rotation.z);
        isRun = true;
    }

}
