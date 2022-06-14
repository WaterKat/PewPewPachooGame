using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships
{
    [CreateAssetMenu(fileName = "SegmentInfo", menuName = "WaterKat/Ship/SegmentInfo", order = 1)]
    public class SegmentInfo : ScriptableObject
    {
        public GameObject Empty;
        public GameObject Blaster;
        public GameObject Booster;
        public GameObject Shield;

        public GameObject GetPrefabInstance(SegmentMonobehavior _shipSegment)
        {
            string segmentNamespace = "WaterKatLLC.Ships.";
            //Debug.Log("GetPrefab: Type: " + _shipSegment.GetType().ToString());
            if (_shipSegment.GetType().ToString() == segmentNamespace+"Empty")
            {
                return ProcessPrefabAndReturnInstance(Empty, _shipSegment);
            }
            else if (_shipSegment.GetType().ToString() == segmentNamespace + "Blaster")
            {
                return ProcessPrefabAndReturnInstance(Blaster, _shipSegment);
            }
            else if (_shipSegment.GetType().ToString() == segmentNamespace + "Booster")
            {
                return ProcessPrefabAndReturnInstance(Booster, _shipSegment);
            }
            else if (_shipSegment.GetType().ToString() == segmentNamespace + "Shield")
            {
                return ProcessPrefabAndReturnInstance(Shield, _shipSegment);
            }

            return null;
        }

        GameObject ProcessPrefabAndReturnInstance(GameObject _prefab, SegmentMonobehavior _segment)
        {
            GameObject instance = Instantiate(_prefab);
            instance.SendMessage("SetTriggerInput", "" , SendMessageOptions.DontRequireReceiver);
            return instance;
        }
    }
}