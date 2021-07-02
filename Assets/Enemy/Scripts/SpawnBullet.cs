using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 15f;

    [SerializeField]
    private Vector2 spawnOffset = Vector2.right;

    private float shoottime = .25f;
    private float lastShot = 0f;
    private void Update()
    {
     if (Time.time - lastShot > shoottime)
        {
            lastShot = Time.time;
            Shoot();
        }   
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.rotation = transform.rotation;
        newBullet.transform.position = transform.position + (transform.rotation * spawnOffset);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.right * bulletSpeed;
        newBullet.SetActive(true);

        Destroy(newBullet, 3f);
    }
}
