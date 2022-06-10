using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships
{
    [System.Serializable]
    public struct SegmentedShip
    {
        public ShipSegment front;
        public ShipSegment back;

        public ShipSegment frontLeft;
        public ShipSegment backLeft;

        public ShipSegment frontRight;
        public ShipSegment backRight;

        public static SegmentedShip Empty
        {
            get
            {
                SegmentedShip ship = new SegmentedShip();
                ship.front = new Empty();
                ship.back = new Empty();
                ship.frontLeft = new Empty();
                ship.frontRight = new Empty();
                ship.backLeft = new Empty();
                ship.backRight = new Empty();
                return ship;

            }
        }

        public static SegmentedShip DebugShip
        {
            get
            {
                SegmentedShip ship = new SegmentedShip();
                ship.front = new Blaster();
                ship.back = new Booster();
                ship.frontLeft = new Shield();
                ship.frontRight = new Shield();
                ship.backLeft = new Shield();
                ship.backRight = new Shield();

                ship.back.TriggerInput = "B";

                return ship;
            }
        }

        public void Print()
        {
            Debug.Log(front.GetType().ToString());
            Debug.Log(back.GetType().ToString());
        }
    }
}