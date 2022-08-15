using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class EnemySpawner2 : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private int count = 100;
        private List<Transform> wayPoints = new List<Transform>();
        void Start()
        {
            wayPoints.Add(transform.Find("WayPoint1").transform);
            wayPoints.Add(transform.Find("WayPoint2").transform);
            wayPoints.Add(transform.Find("WayPoint3").transform);
            wayPoints.Add(transform.Find("WayPoint4").transform);
            wayPoints.Add(transform.Find("WayPoint5").transform);
            InvokeRepeating("GoEnemy", 0f, 0.1f);
        }

        void GoEnemy()
        {
            FollowingEnemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform.parent).GetComponent<FollowingEnemy>();
            enemy.waypoints[0] = wayPoints[Random.Range(0, 4)];
            enemy.waypoints[1] = wayPoints[Random.Range(0, 4)];
            enemy.waypoints[2] = wayPoints[Random.Range(0, 4)];
            enemy.waypoints[3] = wayPoints[Random.Range(0, 4)];
            enemy.waypoints[4] = wayPoints[Random.Range(0, 4)];
            count--;
            if (count < 0) CancelInvoke("GoEnemy");
        }
    }
}
