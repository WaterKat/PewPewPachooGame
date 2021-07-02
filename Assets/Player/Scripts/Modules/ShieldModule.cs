using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;

public class ShieldModule : MonoBehaviour , IPlayerHealthPool
{
    [SerializeField]
    private float shieldDamageCooldown = 3f;    //Time to wait to regen after damage
    [SerializeField]
    private float shieldRegenTime = 0.75f;       // how long between each regen health point 
    private float lastTookDamage = 0;
    private float lastRegenedShield = 0;

    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private int health = 10;

    [SerializeField]
    private Color healthyColor = Color.cyan;
    [SerializeField]
    private Color depletedColor = Color.red;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Collider2D shieldCollider;

    public void TakeDamage(int Damage)
    {
        health = Mathf.Clamp(health - Damage, 0, maxHealth);
        if (health == 0)
        {
            AudioManager.PlaySound("Player_ShieldBreak");
        }
        lastTookDamage = Time.time;
    }

    void Update()
    {
        if (health < maxHealth)
        {
            if (Time.time - lastTookDamage > shieldDamageCooldown)
            {
                if (Time.time - lastRegenedShield > shieldRegenTime)
                {
                    lastRegenedShield = Time.time;
                    health = Mathf.Clamp(health + 1, 0, maxHealth);
                }
            }
        }

        if (health > 0)
        {
            Color shieldColor = healthyColor;
            shieldColor.a = health/(float)maxHealth;
            spriteRenderer.color = shieldColor;
            shieldCollider.enabled = true;
        }
        else
        {
            Color shieldColor = depletedColor;
            shieldColor.a = 1 / (float)maxHealth;
            spriteRenderer.color = shieldColor;
            shieldCollider.enabled = false;
        }
    }
}
