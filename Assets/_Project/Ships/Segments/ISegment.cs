using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships.Segments
{
    public interface ISegment
    {
        int Level { get; }
        string Type { get; }

        void AssignInterfaceValues(ISegment value);
    }
}