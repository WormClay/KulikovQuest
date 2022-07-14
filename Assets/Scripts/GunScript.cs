using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private string tagPlayer = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            other.GetComponent<PlayerObjects>().IsGun = true;
            Debug.Log("Оружие взято");
            Destroy(gameObject);
        }
    }
}
