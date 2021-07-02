using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        public enum InputToggle
        {
            Mouse = 0,
            Controller = 1,
        }
        public InputToggle currentInput = InputToggle.Mouse;

        [SerializeField]
        private float desiredPlayerAngle = 0f;

        [SerializeField]
        private float rotationSpeed = 15f; //Max rotation speed in degrees

        [SerializeField]
        private float deadzone = 0.8f;

        Vector2 controllerInput = new Vector2();

        private Vector2 lastControllerInput = new Vector2();
        private Vector3 lastMouseInput = new Vector3();

        private void Update()
        {
            controllerInput.x = Input.GetAxis("Horizontal2");
            controllerInput.y = -Input.GetAxis("Vertical2");
            controllerInput = Vector2.ClampMagnitude(controllerInput, 1f);

            if (controllerInput.x != lastControllerInput.x)
            {
                currentInput = InputToggle.Controller;
            }
            if (controllerInput.y != lastControllerInput.y)
            {
                currentInput = InputToggle.Controller;
            }

            if (Input.mousePosition != lastMouseInput)
            {
                currentInput = InputToggle.Mouse;
            }


            switch (currentInput)
            {
                case InputToggle.Mouse:
                    Vector3 relativeMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    relativeMousePosition = Vector2.ClampMagnitude(relativeMousePosition, 1f);
                    desiredPlayerAngle = Mathf.Atan2(relativeMousePosition.y, relativeMousePosition.x) * Mathf.Rad2Deg;
                    break;

                case InputToggle.Controller:
                    if (controllerInput.magnitude > deadzone)
                    {
                        desiredPlayerAngle = Mathf.Atan2(controllerInput.y, controllerInput.x) * Mathf.Rad2Deg;
                    }
                    break;
                default:
                    break;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredPlayerAngle), rotationSpeed);

            lastControllerInput = controllerInput;
            lastMouseInput = Input.mousePosition;
        }
    }
}