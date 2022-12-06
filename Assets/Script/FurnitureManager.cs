using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AugmentedRealityCourse;
using AR;

namespace AR
{

    [DefaultExecutionOrder(-100)]
    public class FurnitureManager : MonoBehaviour
    {
        public  Dictionary<string, GameObject> objectsInScene = new Dictionary<string, GameObject>();

        public  Stack<string> orderListOfFurnitureNames = new Stack<string>();
        public  Stack<GameObject> orderListOfFurniture = new Stack<GameObject>();

        public static int furnitureIndex = 0;
        public static GameObject[] furnitureInScene = new GameObject[100];
        

        public static FurnitureManager Instance { get; private set; }

        public GameObject currentFurniture;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void CurrentFurniture(GameObject obj)
        {
            currentFurniture = obj;
        }


        /*

        public  void AddFurniture(GameObject obj)
        {

            Debug.Log("Yep added object : " + obj.name);

            if (!objectsInScene.ContainsKey(obj.name))
            {
                // DebugManager.Instance.AddDebugMessage("whatever you want here....");

                GameObject copy = Instantiate(obj, Vector3.zero, Quaternion.identity);
                copy.SetActive(false);
                copy.name = obj.name; // Make sure its only have one copy of this prefab, vill du ha fler kopior av samma möbel på samma knapp ta bort denna rad OCH byt copy.name längre ned till obj.name

                objectsInScene.Add(copy.name, copy);
                orderListOfFurnitureNames.Push(copy.name);

                currentFurniture = objectsInScene[copy.name];
            } else
            {
                currentFurniture = objectsInScene[obj.name];
            }
        }

        */

        public  void RemoveFurniture(string furnitureName)
        {
            if (objectsInScene.ContainsKey(furnitureName))
            {
                // objectsInScene.Remove(furnitureName); // Tar bort helt

                objectsInScene[furnitureName].SetActive(false); // Döljer objektet i listan
            }
        }

        public  void RemoveLastFurniture()
        {
            //string lastFurnitureName = orderListOfFurnitureNames.Pop();

            //RemoveFurniture(lastFurnitureName);
            if(furnitureInScene[furnitureIndex] != null)
            {
                furnitureInScene[furnitureIndex].SetActive(false);
                furnitureIndex--;
            }

            

        }
    }
}

