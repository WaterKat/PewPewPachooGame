using System.Collections.Generic;
using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships
{
    public interface IShip
    {
        int Experience { get; }
        Dictionary<string, Segment> Segments { get; }
        void AssignInterfaceValues(IShip _ship);
    }
}