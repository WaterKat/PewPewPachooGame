using System.Collections.Generic;
using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships
{
    [System.Serializable]
    public class Ship : IShip
    {
        public int experience = 0;
        int IShip.Experience => experience;

        public Dictionary<string, Segment> segments = new Dictionary<string, Segment>()
        {
            { ShipsConstants.SegmentLocations.Front,      new Segment() },
            { ShipsConstants.SegmentLocations.FrontLeft,  new Segment() },
            { ShipsConstants.SegmentLocations.FrontRight, new Segment() },
            { ShipsConstants.SegmentLocations.BackLeft,   new Segment() },
            { ShipsConstants.SegmentLocations.BackRight,  new Segment() },
            { ShipsConstants.SegmentLocations.Back,       new Segment() },
        };
        Dictionary<string, Segment> IShip.Segments => segments;

        public void AssignInterfaceValues(IShip _ship)
        {
            experience = _ship.Experience;
            segments = _ship.Segments;
        }
    }
}