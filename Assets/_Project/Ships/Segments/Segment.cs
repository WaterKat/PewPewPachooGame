using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships.Segments
{
    [System.Serializable]
    public class Segment : ISegment
    {
        public int level = 0;
        int ISegment.Level => level;


        public string type = SegmentsConstants.Types.Empty;
        string ISegment.Type => type;

        public void AssignInterfaceValues(ISegment _segment)
        {
            level = _segment.Level;
            type = _segment.Type;
        }
    }
}