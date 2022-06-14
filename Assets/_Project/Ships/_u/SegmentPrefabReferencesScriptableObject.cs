using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships
{
    [CreateAssetMenu(fileName = "SegmentPrefabReferences", menuName = "WaterKatLLC/Ships/SegmentPrefabReferences", order = 1)]
    public class SegmentPrefabReferencesScriptableObject : ScriptableObject
    {
        [SerializeField] private GameObject emptyPrefab;

        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

        [SerializeField] private List<GameObject> invalidPrefabs = new List<GameObject>();

        public GameObject GetPrefabInstanceWithStringID(string _prefabID)
        {
            foreach (GameObject prefab in prefabs)
            {
                if (prefab == null) { continue; }
               

                ISegment segment = prefab.GetComponent<ISegment>();

                if (segment == null) { continue; }

                if (segment.Type == _prefabID)
                {
                    return Instantiate(prefab);
                }
            }

            return Instantiate(emptyPrefab);
        }

        private void OnValidate()
        {
            //Move valid prefabs to prefabs list
            GameObject[] invalidPrefabsArray = invalidPrefabs.ToArray();
            for (int i = 0; i < invalidPrefabsArray.Length; i++)
            {
                if (invalidPrefabsArray[i] == null) { continue; }

                ISegment segment = invalidPrefabsArray[i].GetComponent<ISegment>();
                if (segment!=null)
                {
                    prefabs.Add(invalidPrefabsArray[i]);
                    invalidPrefabs[i] = null;
                }
            }
            invalidPrefabs = new List<GameObject>(invalidPrefabsArray);

            //Move invalid prefabs to invalidPrefabs list
            GameObject[] prefabsArray = prefabs.ToArray();
            for (int i = 0; i < prefabsArray.Length; i++)
            {
                if (prefabsArray[i] == null) { continue; }

                ISegment segment = prefabsArray[i].GetComponent<ISegment>();
                if (segment == null)
                {
                    invalidPrefabs.Add(prefabsArray[i]);
                    prefabsArray[i] = null;
                }
            }
            prefabs = new List<GameObject>(prefabsArray);

            //RemoveDuplicates
            prefabs = prefabs.Distinct().ToList();
            invalidPrefabs = invalidPrefabs.Distinct().ToList();

            foreach (GameObject prefab in prefabs)
            {
                if (invalidPrefabs.Contains(prefab))
                {
                    invalidPrefabs.Remove(prefab);
                }
            }

            //Remove Nulls
            prefabs.RemoveAll(item => item == null);
            invalidPrefabs.RemoveAll(item => item == null);
            //add space to add elements
            prefabs.Add(null);
            invalidPrefabs.Add(null);
        }
    }
}
