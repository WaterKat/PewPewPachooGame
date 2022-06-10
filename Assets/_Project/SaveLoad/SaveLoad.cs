using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;

using WaterKatLLC.Ships;

namespace WaterKatLLC.SaveLoadSystem
{
    public static class SaveLoad
    {
        public static void CheckDirectory(string _directory)
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
        }

        public static void SaveShipData(SegmentedShip _ship, string _saveName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string folderPath = Application.persistentDataPath +  "/ShipData/" ;
            CheckDirectory(folderPath);
            string fileName = _saveName + ".shipdata";
            string path = folderPath + fileName;

            FileStream fileStream = new FileStream(path, FileMode.Create);

            //SegmentedShipData shipData = new SegmentedShipData();
            SegmentedShipData shipData = new SegmentedShipData(_ship);

            binaryFormatter.Serialize(fileStream, shipData);
            fileStream.Close();

            Debug.Log("SaveLoad: Saved \""+_saveName+"\" to " + path);
        }

        public static SegmentedShip LoadShipData(string _saveName)
        {
            string folderPath = Application.persistentDataPath + "/ShipData/";
            CheckDirectory(folderPath);
            string fileName = _saveName + ".shipdata";
            string path = folderPath + fileName;

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                SegmentedShipData shipData = binaryFormatter.Deserialize(fileStream) as WaterKatLLC.Ships.SegmentedShipData;

                fileStream.Close();

                Debug.Log("SaveLoad: Loaded \"" + _saveName + "\" from " + path);
                //return shipData.Ship;
                return SegmentedShip.Empty;
            }
            else
            {
                Debug.LogError("SaveLoad: Save file not found at " + path);
                return SegmentedShip.Empty;
            }

        }

    }
}