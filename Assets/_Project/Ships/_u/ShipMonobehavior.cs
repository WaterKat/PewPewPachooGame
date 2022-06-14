using System.Collections.Generic;
using UnityEngine;
using WaterKatLLC.Ships.Segments;

namespace WaterKatLLC.Ships
{
    public class ShipMonobehavior : MonoBehaviour, IShip
    {
        [Header("GlobalConfiguration")]
            [SerializeField] private SegmentPrefabReferencesScriptableObject segmentPrefabReferences;
        
        [Header("LocalConfiguration")]
            [SerializeField] private GameObject segmentContainer;
            private Dictionary<string, GameObject> segmentContainers = new Dictionary<string, GameObject>();

        [Header("IShip")]
            [SerializeField] private int experience = 0;
            public int Experience => experience;

            [SerializeField] private Dictionary<string, Segment> segments = new Dictionary<string, Segment>();
            public Dictionary<string, Segment> Segments => segments;

        [Header("Logging")]
            [SerializeField] private bool displayLogs = false;

        private new Transform transform => throw new System.NotSupportedException();

        private void Log(string _log)
        {
            if (!displayLogs) return;

            Debug.Log(_log);
        }

        public void ReloadShip()
        {
            InitSegmentContainers(ref segmentContainers, ref segmentContainer);
            InitShipPrefabs(ref segments, ref segmentContainers, ref segmentPrefabReferences);
        }

        void Awake()
        {
            InitSegmentContainers(ref segmentContainers, ref segmentContainer);
        }

        public void AssignInterfaceValues(IShip _ship)
        {
            experience = _ship.Experience;
            segments = _ship.Segments;
        }

        private void InitSegmentContainers(ref Dictionary<string,GameObject> _segmentContainers, ref GameObject _segmentContainer)
        {
            _segmentContainers.Clear();

            Transform[] childGameObjects = _segmentContainer.GetComponentsInChildren<Transform>();
            foreach (var childGO in childGameObjects)
            {
                if (childGO == null) { continue; }
                if (childGO == _segmentContainer.transform) { continue; }
                if (childGO.parent != _segmentContainer.transform) { continue; }

                if (_segmentContainers.ContainsKey(childGO.gameObject.name)) { continue; }

                _segmentContainers.Add(childGO.gameObject.name,childGO.gameObject);
            }

        }

        private void InitShipPrefabs(ref Dictionary<string, Segment> _segments, ref Dictionary<string, GameObject> _segmentContainers, ref SegmentPrefabReferencesScriptableObject _prefabReferences)
        {
            foreach (var stringContainerPair in _segmentContainers)
            {
                ClearChildren(stringContainerPair.Value);
            }

            foreach (var stringSegmentPair in _segments)
            {
                if (!_segmentContainers.ContainsKey(stringSegmentPair.Key))
                {
                    Log("ShipMonobehavior: " + "Does have not container \"" + "\"");
                    continue;
                }

                GameObject prefabInstace = _prefabReferences.GetPrefabInstanceWithStringID(stringSegmentPair.Value.type);
                prefabInstace.transform.parent = _segmentContainers[stringSegmentPair.Key].transform;
                prefabInstace.transform.localPosition = Vector3.zero;
                prefabInstace.transform.localRotation = Quaternion.identity;

                prefabInstace.GetComponent<ISegment>().AssignInterfaceValues(stringSegmentPair.Value);
            }
        }

        private void ClearChildren(GameObject _container)
        {
            Transform[] children = _container.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].gameObject == _container)
                    continue;

                if (children[i].gameObject != null)
                {
                    Destroy(children[i].gameObject);
                }
            }

        }

    }
}