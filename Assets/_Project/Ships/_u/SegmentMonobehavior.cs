using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships.Segments
{
    public class SegmentMonobehavior : MonoBehaviour, ISegment
    {
        [SerializeField] private int level;
        public int Level => level;

        [SerializeField] private string type = "Empty";
        public string Type => type;

        public void AssignInterfaceValues(ISegment _segment)
        {
            level = _segment.Level;
            type = _segment.Type;
        }
    }
}
