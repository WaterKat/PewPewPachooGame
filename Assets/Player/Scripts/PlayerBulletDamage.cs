using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamage : MonoBehaviour , IPlayerHealthPool
{
    [SerializeField]
    private int damage = 1;

    public void TakeDamage(int Damage)
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IEnemyHealthPool damageAble = collision.collider.gameObject.GetComponentInParent<IEnemyHealthPool>();
        if (damageAble != null)
        {
            damageAble.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
