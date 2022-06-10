using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace WaterKatLLC.InputManagement
{
    public class ShipInput : MonoBehaviour
    {
        private Vector2 move;
        public Vector2 Move { get => move; private set => move = value; }

        private Vector2 look;
        public Vector2 Look { get => look; private set => look = value; }

        public void OnMove(InputAction.CallbackContext _context)
        {
            Move = _context.ReadValue<Vector2>();
        }
        public void OnLook(InputAction.CallbackContext _context)
        {
            Look = _context.ReadValue<Vector2>();
        }
    }
}