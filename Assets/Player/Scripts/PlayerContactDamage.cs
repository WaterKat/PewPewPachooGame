using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactDamage : MonoBehaviour
{
    [SerializeField]
    private float rebound = 20f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private Rigidbody2D localRigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IEnemyHealthPool damageAble = collision.collider.gameObject.GetComponentInParent<IEnemyHealthPool>();
        if (damageAble != null)
        {
            damageAble.TakeDamage(damage);
            localRigidbody.velocity += (collision.contacts[0].point - (Vector2)transform.position) * -rebound;
        }
    }
}
