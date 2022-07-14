using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private string tagPlayer = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            Debug.Log("Ключ найден");
            other.GetComponent<PlayerObjects>().IsKey = true;
            Destroy(gameObject);
        }
    }
}
