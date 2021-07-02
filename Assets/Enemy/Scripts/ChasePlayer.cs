using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 45f;
    [SerializeField]
    private float Angle = 0f;

    [SerializeField]
    private float MaxVelocity = 5f;
    [SerializeField]
    private float Acceleration = 5f;
    private float coefficient = 0f;

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

        targetDirection = (playerTarget.transform.position - transform.position).normalized;

        Drag = 0.5f * enemyRigidbody.velocity.normalized * Mathf.Pow(enemyRigidbody.velocity.magnitude, 2) * coefficient;
        DesiredAcceleration = targetDirection * Acceleration;

        if (Acceleration != 0)
        {
            enemyRigidbody.velocity += (Drag + DesiredAcceleration) * Time.deltaTime;
        }
        Angle += turnSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

}
