using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimAtPlayer : MonoBehaviour
{

    [SerializeField]
    private float desiredEnemyAngle = 0f;
    [SerializeField]
    private float rotationSpeed = 10f; //Max rotation speed in degrees

    [SerializeField]
    private GameObject playerTarget;

    private void Update()
    {
        if (playerTarget == null)
        {
            playerTarget = GameObject.FindWithTag("Player");
            if (playerTarget == null)
            {
                return;
            }
        }

        Vector3 relativeTargetPosition = playerTarget.transform.position - transform.position;
        relativeTargetPosition = Vector2.ClampMagnitude(relativeTargetPosition, 1f);
        desiredEnemyAngle = Mathf.Atan2(relativeTargetPosition.y, relativeTargetPosition.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredEnemyAngle), rotationSpeed);

    }
}
