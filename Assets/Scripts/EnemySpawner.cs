using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest {
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private int count = 20;
        private Transform wayPoint1;
        private Transform wayPoint2;
        private Transform wayPoint3;
        private Transform wayPoint4;
        private Transform wayPoint5;
        void Start()
        {
            wayPoint1 = transform.Find("WayPoint1").transform;
            wayPoint2 = transform.Find("WayPoint2").transform;
            wayPoint3 = transform.Find("WayPoint3").transform;
            wayPoint4 = transform.Find("WayPoint4").transform;
            wayPoint5 = transform.Find("WayPoint5").transform;
            InvokeRepeating("GoEnemy", 1f, 2f);
        }

        void GoEnemy() 
        {
            FollowingEnemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform.parent).GetComponent<FollowingEnemy>();
            enemy.waypoints[0] = wayPoint1;
            enemy.waypoints[1] = wayPoint2;
            enemy.waypoints[2] = wayPoint3;
            enemy.waypoints[3] = wayPoint4;
            enemy.waypoints[4] = wayPoint5;
            count--;
            if (count < 0) CancelInvoke("GoEnemy");
        }
    }
}
