using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurreleScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnStep = 1f;
    [SerializeField] private float angularSpeed = 0.5f;
    private bool isVisiblePlayer = false;
    private Transform player;
    private float nextSpawnTime;
    private string tagPlayer = "Player";

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(CheckVisiblePlayer());
    }


    private void OnDisable()
    {
        StopCoroutine(CheckVisiblePlayer());
    }

    void Update()
    {
        //CheckVisiblePlayer();
        if (isVisiblePlayer)
        {
            LookAtPlayer();
            Shot();
        }
    }

    void LookAtPlayer() 
    {
        var direction = player.transform.position - transform.position;
        var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    void Shot() 
    {
        if (Time.time > nextSpawnTime) 
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            nextSpawnTime = Time.time + spawnStep;
        }
    }

    IEnumerator CheckVisiblePlayer() 
    {
        while (enabled)
        {
            if (Physics.Raycast(new Ray(transform.position, player.position - transform.position), out RaycastHit hitInfo, 15f))
                if (hitInfo.transform.CompareTag(tagPlayer)) isVisiblePlayer = true;
                else isVisiblePlayer = false;
            yield return new WaitForSeconds(spawnStep);
        }
        yield return null;
    }

}
