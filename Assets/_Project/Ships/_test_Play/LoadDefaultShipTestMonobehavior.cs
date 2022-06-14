using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaterKatLLC.Ships;
using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships.Tests
{
    public class LoadDefaultShipTestMonobehavior : MonoBehaviour
    {
        [SerializeField] private ShipMonobehavior shipMonoBehavior;

        void Start()
        {
            LoadDebug();
        }

        [ContextMenu("Load_Debug_Ship")]
        public void LoadDebug()
        {
            Ship ship = new Ship();
            ship.segments = new Dictionary<string, Segment>()
            {
                { ShipsConstants.SegmentLocations.Front , new Segment() { type = SegmentsConstants.Types.Blaster } },
                { ShipsConstants.SegmentLocations.FrontLeft , new Segment() { type = SegmentsConstants.Types.Shield } },
                { ShipsConstants.SegmentLocations.FrontRight , new Segment() { type = SegmentsConstants.Types.Shield } },

                { ShipsConstants.SegmentLocations.BackLeft , new Segment() { type = SegmentsConstants.Types.Shield } },
                { ShipsConstants.SegmentLocations.BackRight , new Segment() { type = SegmentsConstants.Types.Shield } },
                { ShipsConstants.SegmentLocations.Back , new Segment() { type = SegmentsConstants.Types.Booster } },
            };

            shipMonoBehavior.AssignInterfaceValues(ship);
            shipMonoBehavior.ReloadShip();
        }

    }
}
