using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

using WaterKatLLC.InputManagement;

namespace WaterKatLLC.Ships
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private ShipInput shipInput;

        [SerializeField]
        private float MaxVelocity = 15f;
        [SerializeField]
        private float Acceleration = 40f;
        private float coefficient = 0f;


        [SerializeField]
        private float inputBrakeThreshold = 0.8f;
        [SerializeField]
        private float brakeThreshold = 1f;

        private Rigidbody2D playerRigidbody = null;

        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();

            coefficient = (-2 * Acceleration) / Mathf.Pow(MaxVelocity, 2);
        }

        private Vector2 moveInput = new Vector2();
        private Vector2 Drag = new Vector2();
        private Vector2 DesiredAcceleration = new Vector2();

        void Update()
        {
            moveInput = shipInput.Move;
            /*
            playerInput.x = UnityEngine.Input.GetAxis("Horizontal");    //Refresh Player Input
            playerInput.y = UnityEngine.Input.GetAxis("Vertical");
            */

            Drag = 0.5f * playerRigidbody.velocity.normalized * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) * coefficient;

            Drag *= Mathf.Lerp(1f,3f,Mathf.Max(-Vector2.Dot(moveInput, playerRigidbody.velocity),0));

            DesiredAcceleration = moveInput * Acceleration;

            playerRigidbody.velocity += (Drag + DesiredAcceleration) * Time.deltaTime;

            /*
            if (playerInput.magnitude < inputBrakeThreshold)
            {
                playerRigidbody.velocity *= 0.95f;
            }
            */
            if ((playerRigidbody.velocity.magnitude < brakeThreshold)&&!(moveInput.magnitude>0))
            {
                playerRigidbody.velocity *= 0.915f;
            }
            
        }
    }
}