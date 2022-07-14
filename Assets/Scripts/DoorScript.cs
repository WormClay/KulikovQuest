using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private string tagPlayer = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            Debug.Log("�����");
            if (other.GetComponent<PlayerObjects>().IsKey) Destroy(gameObject);
        }
    }
}
