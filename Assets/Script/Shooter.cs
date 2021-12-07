using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float timeToDestroyBullet = 5f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] bool isBot;
    public bool isFiring;
    Coroutine fireCoroutine;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }

    void Start()
    {
        if (isBot)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject game = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = game.GetComponent<Rigidbody2D>();
            if (rigidbody != null && !isBot)
                rigidbody.velocity = new Vector2(0, bulletSpeed);
            else if (rigidbody != null && isBot)
                rigidbody.velocity = new Vector2(0, -bulletSpeed);
            Destroy(game, timeToDestroyBullet);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
