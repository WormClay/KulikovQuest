using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShots : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public AudioClip bulletClip;
    public AudioClip bombClip;
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
        Bomb();
    }

    private void Shot()
    {
        if (playerObjects.IsGun && Input.GetMouseButtonDown(0))
        {
            if (bulletPrefab != null)
            {
                audioSource.PlayOneShot(bulletClip);
                var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, (transform.position.y + 0.5f), transform.position.z), cameraTransform.rotation);
            }
        }
    }

    private void Bomb()
    {
        if (playerObjects.IsBomb && Input.GetMouseButtonDown(1))
        {
            if (bombPrefab != null)
            {
                audioSource.PlayOneShot(bombClip);
                var bullet = Instantiate(bombPrefab, new Vector3(transform.position.x + transform.forward.x, transform.position.y + 0.5f, transform.position.z + transform.forward.z), cameraTransform.rotation);
            }
        }
    }

}
