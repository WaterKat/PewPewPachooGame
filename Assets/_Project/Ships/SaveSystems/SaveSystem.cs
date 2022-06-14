using System;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

namespace WaterKatLLC.Ships.SaveSystems
{
    public static class SaveSystem
    {
        public static readonly string shipDataDirectory = Application.persistentDataPath + "/ShipData/";
        public static readonly string shipDataFileExtension = ".shipdata";

        public static void SaveLog(string _log)
        {
            Debug.Log(_log);
        }

        public static void CreateDirectory(string _directory)
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
        }

        public static void SaveShipData(IShip _ship, string _saveName)
        {
            //Data to be saved
            Ship shipData = new Ship();
            shipData.AssignInterfaceValues(_ship);
            string shipDataJson = JsonUtility.ToJson(shipData);

            //Manage Directories
            CreateDirectory(shipDataDirectory);
            string filePath = shipDataDirectory + _saveName + shipDataFileExtension;

            //SaveFile
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            binaryFormatter.Serialize(fileStream, shipDataJson);
            fileStream.Close();

            //
            SaveLog("SaveLoad: Saved \"" + _saveName + "\" to " + filePath);
        }

        public static IShip LoadShipData(string _saveName)
        {
            //Data to be loaded
            Ship shipData = new Ship();
            string shipDataJson = "";

            //Manage Directories
            CreateDirectory(shipDataDirectory);
            string filePath = shipDataDirectory + _saveName + shipDataFileExtension;

            //File Missing Guard Clause
            if (!File.Exists(filePath))
            {
                SaveLog("SaveLoad: Save file not found at " + filePath);
                return shipData;
            }

            //LoadFile
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            shipDataJson = binaryFormatter.Deserialize(fileStream) as string;
            shipData = JsonUtility.FromJson<Ship>(shipDataJson);

            fileStream.Close();

            //
            SaveLog("SaveLoad: Loaded \"" + _saveName + "\" from " + filePath);
            return shipData;
        }

    }
}