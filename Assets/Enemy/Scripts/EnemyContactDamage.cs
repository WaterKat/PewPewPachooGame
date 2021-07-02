using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField]
    private float rebound = 20f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private Rigidbody2D enemyRigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerHealthPool damageAble = collision.collider.gameObject.GetComponentInParent<IPlayerHealthPool>();
        if (damageAble != null)
        {
            damageAble.TakeDamage(damage);
            enemyRigidbody.velocity += (collision.contacts[0].point - (Vector2)transform.position) * -rebound;
        }
    }
}
