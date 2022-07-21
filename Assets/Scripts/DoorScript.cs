using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private string tagPlayer = "Player";
    [SerializeField] private string inventarCheckName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            Debug.Log("Door");
            if (Inventar.CheckInventar(inventarCheckName)) 
            {
                if (Inventar.DelFromInventar(inventarCheckName)) Destroy(gameObject);
            }
        }
    }
}
