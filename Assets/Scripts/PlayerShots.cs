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
    [SerializeField] private string inventarCheckNameGun;
    [SerializeField] private string inventarCheckNameBomb;

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
        if (/*Inventar.CheckInventar(inventarCheckNameGun) && */Input.GetMouseButtonDown(0))
        {
            if (bulletPrefab != null)
            {
                audioSource.PlayOneShot(bulletClip);
                var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, (transform.position.y + 0.5f), transform.position.z), cameraTransform.rotation);
                bullet.GetComponent<BulletScript>().playerObjects = playerObjects;
            }
        }
    }

    private void Bomb()
    {
        if (Inventar.CheckInventar(inventarCheckNameBomb) && Input.GetMouseButtonDown(1))
        {
            if (bombPrefab != null)
            {
                audioSource.PlayOneShot(bombClip);
                var bomb = Instantiate(bombPrefab, new Vector3(transform.position.x + transform.forward.x, transform.position.y + 0.5f, transform.position.z + transform.forward.z), cameraTransform.rotation);
                bomb.GetComponent<BombScript>().playerObjects = playerObjects;
            }
        }
    }

}
