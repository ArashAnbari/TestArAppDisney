using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


namespace AR
{
    public class TapToPlace : MonoBehaviour
    {
        //Variabler        
        // private GameObject prefabInstance;
        public static GameObject spawnedObject = null;
        private bool isPlaneToggled = true;

        static public bool placeNewFurniture = true;

        private static List<ARRaycastHit> hitList = new List<ARRaycastHit>();

        //Referencer
        [SerializeField]
        private ARRaycastManager raycastManager;
        [SerializeField]
        private ARPlaneManager planeManager;

        public bool TryGetTouchPos(out Vector2 touchPos)
        {            
            if (Input.touchCount == 1)
            {
                touchPos = Input.GetTouch(0).position;
                return true;
            }
            touchPos = default;
            return false;
        }
        

        public void TogglePlaneDetection()
        {
            isPlaneToggled = !isPlaneToggled;

            planeManager.SetTrackablesActive(isPlaneToggled);
            planeManager.planePrefab.SetActive(isPlaneToggled);

            foreach(ARPlane plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(isPlaneToggled);
            }
        }

        private bool PhysicRayCastBlockedByUi(Vector2 touchPos)
        {
            if (PointerOverUI.IsPointerOverUIObject(touchPos))
            {
                Debug.Log("On UI");
                return false;                
            }

            return raycastManager.Raycast(touchPos, hitList, TrackableType.PlaneWithinPolygon);
        }

        private void Update()
        {
            if(!TryGetTouchPos(out Vector2 touchPos))
            {
                return;
            }           

            if (raycastManager.Raycast(touchPos, hitList, TrackableType.Planes) && !UI.menuOpen && PhysicRayCastBlockedByUi(touchPos))
            {
                Pose hitPose = hitList[0].pose;                

                if (placeNewFurniture)
                {
                    placeNewFurniture = false;

                    spawnedObject = Instantiate(FurnitureManager.Instance.currentFurniture, hitPose.position, hitPose.rotation);

                    FurnitureManager.furnitureIndex++;
                    FurnitureManager.furnitureInScene[FurnitureManager.furnitureIndex] = spawnedObject;

                    FurnitureManager.Instance.orderListOfFurniture.Push(FurnitureManager.Instance.currentFurniture);
                    
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }
}


