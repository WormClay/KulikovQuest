using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private string tagPlayer = "Player";
    [SerializeField] private string inventarName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            Debug.Log("Gun taked");
            if (inventarName != null) Inventar.AddToInventar(inventarName);
            Debug.Log("Inventar=" + Inventar.GetInventar());
            Destroy(gameObject);
        }
    }
}
