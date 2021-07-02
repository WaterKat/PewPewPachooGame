using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;

public class ShootModule : MonoBehaviour, IModules
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 15f;

    [SerializeField]
    private Vector2 spawnOffset = Vector2.right;

    [SerializeField]
    private string triggerInput = "A";
    public string TriggerInput
    {
        get
        {
            return triggerInput;
        }
    }

    public void TriggerModule(string Input)
    {
        if (Input != TriggerInput) { return; }

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.rotation = transform.rotation*Quaternion.Euler(0,0,Random.Range(-10,10));
        newBullet.transform.position = transform.position + (newBullet.transform.rotation * spawnOffset);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.right * bulletSpeed;
        newBullet.SetActive(true);
        AudioManager.PlaySound("Player_Shoot");
    }
}
