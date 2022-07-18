using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBomb : MonoBehaviour
{
    private string tagPlayer = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            other.GetComponent<PlayerObjects>().IsBomb = true;
            Debug.Log("Bomb taked");
            Destroy(gameObject);
        }
    }
}
