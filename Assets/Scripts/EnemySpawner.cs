using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    //private int count = 10;
    void Start()
    {
        InvokeRepeating("GoEnemy", 1f, 2f);
    }

    void GoEnemy() 
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
