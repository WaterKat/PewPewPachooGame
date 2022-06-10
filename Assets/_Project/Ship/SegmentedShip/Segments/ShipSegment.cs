using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships
{
    [System.Serializable]
    public class ShipSegment
    {
        [Header("Filler")]
        private string triggerInput = "A";
        public string TriggerInput { get { return triggerInput; } set { triggerInput = value; } }
    }
}