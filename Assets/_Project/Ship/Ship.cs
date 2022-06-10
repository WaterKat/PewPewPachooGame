using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private SegmentInfo segmentInfo;
        [Space(10)]
        [SerializeField] private GameObject frontContainer;
        [SerializeField] private GameObject backContainer;
        [SerializeField] private GameObject frontLeftContainer;
        [SerializeField] private GameObject frontRightContainer;
        [SerializeField] private GameObject backLeftContainer;
        [SerializeField] private GameObject backRightContainer;
        [Space(10)]

        private SegmentedShip ship;


        [ContextMenu("Load_Debug_Ship")]
        public void LoadDebug()
        {
            SetShip(SegmentedShip.DebugShip);
            LoadShip();
        }

        public void LoadShip()
        {
            ClearChildren(frontContainer);
            ClearChildren(backContainer);
            ClearChildren(frontLeftContainer);
            ClearChildren(frontRightContainer);
            ClearChildren(backLeftContainer);
            ClearChildren(backRightContainer);

            AssignPrefabtoContainer(frontContainer, segmentInfo.GetPrefabInstance(ship.front));
            AssignPrefabtoContainer(backContainer, segmentInfo.GetPrefabInstance(ship.back));
            AssignPrefabtoContainer(frontLeftContainer, segmentInfo.GetPrefabInstance(ship.frontLeft));
            AssignPrefabtoContainer(frontRightContainer, segmentInfo.GetPrefabInstance(ship.frontRight));
            AssignPrefabtoContainer(backLeftContainer, segmentInfo.GetPrefabInstance(ship.backLeft));
            AssignPrefabtoContainer(backRightContainer, segmentInfo.GetPrefabInstance(ship.backRight));

            SendMessage("OnShipLoad", SendMessageOptions.DontRequireReceiver);
        }

        private void AssignPrefabtoContainer(GameObject _container,GameObject _prefabInstance)
        {
            _prefabInstance.transform.parent = _container.transform;
            _prefabInstance.transform.localRotation = Quaternion.identity;
            _prefabInstance.transform.localPosition = Vector3.zero;
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
            //Debug.Log("Cleared: " + _container.ToString());
        }

        public void SetShip(SegmentedShip _shipInfo)
        {
            ship = _shipInfo;
        }
    }
}