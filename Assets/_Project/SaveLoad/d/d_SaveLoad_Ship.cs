using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaterKatLLC.Ships;
using WaterKatLLC.SaveLoadSystem;

public class d_SaveLoad_Ship : MonoBehaviour
{
    [SerializeField] private SegmentedShip ship = new SegmentedShip();
    string saveName = "Debug_Ship";

    public void SaveShip()
    {
        SaveLoad.SaveShipData(ship, saveName);
    }

    public void LoadShip()
    {
        SaveLoad.LoadShipData(saveName);
        ship.Print();
    }

}
