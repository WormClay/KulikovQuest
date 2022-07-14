using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShots : MonoBehaviour
{
    public GameObject bulletPrefab;
    private PlayerObjects playerObjects;
    private AudioSource audioSource;
    private Transform cameraTransform;

    void Start()
    {
        playerObjects = transform.GetComponent<PlayerObjects>();
        audioSource = transform.GetComponent<AudioSource>();
        cameraTransform = transform.Find("Camera").transform;
    }

    void Update()
    {
        Shot();
    }

    private void Shot()
    {
        if (playerObjects.IsGun && Input.GetMouseButtonDown(0))
        {
            if (bulletPrefab != null)
            {
                audioSource.Play();
                var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, (transform.position.y + 0.5f), transform.position.z), cameraTransform.rotation);
            }
        }
    }

}
