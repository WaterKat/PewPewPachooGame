using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class ChaseThenStayAway : MonoBehaviour
{
    [SerializeField]
    private float MaxVelocity = 5f;
    [SerializeField]
    private float Acceleration = 5f;
    private float coefficient = 0f;

    [SerializeField]
    private float desiredDistance = 5f;

    [SerializeField]
    private Rigidbody2D enemyRigidbody;

    private GameObject playerTarget;


    void Start()
    {
        coefficient = (-2 * Acceleration) / Mathf.Pow(MaxVelocity, 2);
    }

    private Vector2 targetDirection = new Vector2();
    private Vector2 Drag = new Vector2();
    private Vector2 DesiredAcceleration = new Vector2();

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

        targetDirection = Vector3.ClampMagnitude(playerTarget.transform.position - transform.position,1);

        if (Vector3.Distance(transform.position, playerTarget.transform.position) < desiredDistance)
        {
            targetDirection *= -1f;
        }
        Drag = 0.5f * enemyRigidbody.velocity.normalized * Mathf.Pow(enemyRigidbody.velocity.magnitude, 2) * coefficient;
        DesiredAcceleration = targetDirection * Acceleration;

        enemyRigidbody.velocity += (Drag + DesiredAcceleration) * Time.deltaTime;
    }

}
