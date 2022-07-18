using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedScript : MonoBehaviour
{
    private string tagPlayer = "Player";
    private int med = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            other.GetComponent<PlayerObjects>().Med(med);
            Destroy(gameObject);
        }
    }
}
