using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;

public class EnemyShootBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 30f;

    [SerializeField]
    private Vector2 spawnOffset = Vector2.right;

    private float shootCooldown = 1.25f;
    private float shoottime = .15f;
    private int bulletNumber = 3;
    private float lastShot = 0f;

    private void Start()
    {
        lastShot = UnityEngine.Random.Range(0, shootCooldown * 2);
    }
    private void Update()
    {
        if (Time.time - lastShot > shootCooldown+(shoottime*bulletNumber))
        {
            lastShot = Time.time;
            StartCoroutine(shootXManyBullets(bulletNumber, shoottime));
        }
    }

    IEnumerator shootXManyBullets(int bulletNumber,float timebetweenbullets)
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Shoot();
            float timeElapsed = 0;
            while (timeElapsed < timebetweenbullets)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }

    }

    public void Shoot()
    {
        

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.rotation = transform.rotation * Quaternion.Euler(0,0,UnityEngine.Random.Range(-20f,20f));
        newBullet.transform.position = transform.position + (transform.rotation * spawnOffset);
        newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.rotation * Vector2.right * bulletSpeed;
        newBullet.SetActive(true);
        AudioManager.PlaySound("Enemy_Shoot");

        Destroy(newBullet, 3f);
    }
}
