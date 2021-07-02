using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace WaterKat.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float MaxVelocity = 5f;
        [SerializeField]
        private float Acceleration = 5f;
        private float coefficient = 0f;


        [SerializeField]
        private float inputBrakeThreshold = 0.25f;
        [SerializeField]
        private float brakeThreshold = 0.2f;

        private Rigidbody2D playerRigidbody = null;

        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();

            coefficient = (-2 * Acceleration) / Mathf.Pow(MaxVelocity, 2);
        }

        private Vector2 playerInput = new Vector2();
        private Vector2 Drag = new Vector2();
        private Vector2 DesiredAcceleration = new Vector2();

        void Update()
        {
            playerInput.x = Input.GetAxis("Horizontal");    //Refresh Player Input
            playerInput.y = Input.GetAxis("Vertical");

            Drag = 0.5f * playerRigidbody.velocity.normalized * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) * coefficient;

            Drag *= Mathf.Lerp(1f,3f,Mathf.Max(-Vector2.Dot(playerInput, playerRigidbody.velocity),0));

            DesiredAcceleration = playerInput * Acceleration;

            playerRigidbody.velocity += (Drag + DesiredAcceleration) * Time.deltaTime;

            /*
            if (playerInput.magnitude < inputBrakeThreshold)
            {
                playerRigidbody.velocity *= 0.95f;
            }
            */
            if ((playerRigidbody.velocity.magnitude < brakeThreshold)&&!(playerInput.magnitude>0))
            {
                playerRigidbody.velocity *= 0.915f;
            }
            
        }
    }
}