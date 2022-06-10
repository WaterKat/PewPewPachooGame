using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;


namespace WaterKatLLC.InputManagement
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class DirectionFromCenterProcessor : InputProcessor<Vector2>
    {
#if UNITY_EDITOR
        static DirectionFromCenterProcessor()
        {
            Initialize();
        }
#endif
        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<DirectionFromCenterProcessor>();
        }

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            Vector2 windowSize = new Vector2(Screen.width, Screen.height);
            return (value - (windowSize/2)).normalized;
        }
    }
}