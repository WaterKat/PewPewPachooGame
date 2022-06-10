using System;

namespace WaterKatLLC.Ships
{
    [Serializable]
    public class SegmentedShipData
    {
        public int testInt;
       
        private SegmentedShip ship;        
        public SegmentedShip Ship { get; set; }
        
        public SegmentedShipData() { }

        public SegmentedShipData(SegmentedShip ship)
        {
            this.ship = ship;
        }
    }
}