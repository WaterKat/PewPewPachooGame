using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;
using WaterKat.TimeW;

public class PlayerHealth : MonoBehaviour , IPlayerHealthPool
{
    [SerializeField]
    public int health = 20;
    [SerializeField]
    public int maxHealth = 20;

    [SerializeField]
    private GameObject display;

    public void TakeDamage(int Damage)
    {
        health = Mathf.Clamp(health - Damage, 0, maxHealth);
        AudioManager.PlaySound("Player_DamageTake");

        if (health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        AudioManager.PlaySound("Player_Death");
        //health = 100;
        display.SetActive(false);
        FindObjectOfType<SurvivalCounter>().enabled = false;
        ExplosionManager.ExplodeAtPoint(transform.position);
        TaskManager.AddTask(ReloadScene, 3f);
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
