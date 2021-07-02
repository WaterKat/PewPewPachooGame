using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;

public class EnemyHealth : MonoBehaviour , IEnemyHealthPool
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private int maxHealth = 3;

    public void TakeDamage(int Damage)
    {
        health = Mathf.Clamp(health - Damage, 0, maxHealth);
        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ExplosionManager.ExplodeAtPoint(transform.position);
        AudioManager.PlaySound("Enemy_Death");
        Destroy(this.gameObject);
    }
}
