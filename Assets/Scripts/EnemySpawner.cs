using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int count = 20;
    private Transform wayPoint1;
    private Transform wayPoint2;
    private Transform wayPoint3;
    void Start()
    {
        wayPoint1 = transform.Find("WayPoint1").transform;
        wayPoint2 = transform.Find("WayPoint2").transform;
        wayPoint3 = transform.Find("WayPoint3").transform;
        InvokeRepeating("GoEnemy", 1f, 2f);
    }

    void GoEnemy() 
    {
        FollowingEnemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform.parent).GetComponent<FollowingEnemy>();
        enemy.waypoints[0] = wayPoint1;
        enemy.waypoints[1] = wayPoint2;
        enemy.waypoints[2] = wayPoint3;
        count--;
        if (count < 0) CancelInvoke("GoEnemy");
    }
}
