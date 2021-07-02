using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour , IEnemyHealthPool
{
    [SerializeField]
    private int damage = 1;

    public void TakeDamage(int Damage)
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayerHealthPool damageAble = collision.collider.gameObject.GetComponentInParent<IPlayerHealthPool>();
        if (damageAble != null)
        {
            damageAble.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
