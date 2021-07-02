using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField]
    private float rebound = 20f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private Rigidbody2D localRigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MineScript mineScript = collision.collider.gameObject.GetComponentInParent<MineScript>();
        if (mineScript != null)
        {
            localRigidbody.velocity += (collision.contacts[0].point - (Vector2)transform.position) * -rebound;

            return;
        }
        
        IEnemyHealthPool damageAbleEnemy = collision.collider.gameObject.GetComponentInParent<IEnemyHealthPool>();
        if (damageAbleEnemy != null)
        {
            damageAbleEnemy.TakeDamage(damage);
            localRigidbody.velocity += (collision.contacts[0].point - (Vector2)transform.position) * -rebound;
        }

        IPlayerHealthPool damageAblePlayer = collision.collider.gameObject.GetComponentInParent<IPlayerHealthPool>();
        if (damageAblePlayer != null)
        {
            damageAblePlayer.TakeDamage(damage);
            localRigidbody.velocity += (collision.contacts[0].point - (Vector2)transform.position) * -rebound;
        }
    }
}
