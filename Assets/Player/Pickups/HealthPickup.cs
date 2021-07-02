using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private int healthAdded = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Test");
        IPlayerHealthPool damageAble = collider.gameObject.GetComponentInParent<IPlayerHealthPool>();
        if (damageAble != null)
        {
            damageAble.TakeDamage(-healthAdded);
            Destroy(this.gameObject);
        }
    }
}
