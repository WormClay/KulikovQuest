using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBomb : MonoBehaviour
{
    private string tagPlayer = "Player";
    [SerializeField] private string inventarName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            //other.GetComponent<PlayerObjects>().IsBomb = true;
            Debug.Log("Bomb taked");
            if (inventarName != null) Inventar.AddToInventar(inventarName);
            Debug.Log("Inventar=" + Inventar.GetInventar());
            Destroy(gameObject);

        }
    }
}
