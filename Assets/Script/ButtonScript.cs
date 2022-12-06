using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AR
{
    public class ButtonScript : MonoBehaviour
    {
        private Button button;

        [SerializeField]
        private GameObject prefabToInstaniate;

        // Start is called before the first frame update
        void Start()
        {
            

            button = this.GetComponent<Button>();

            //FurnitureManager copy = FurnitureManager.Instance;

            if (button != null)
            {
                button.onClick.AddListener(() =>
                {
                    Debug.Log("Yep it has been clicked");

                    FurnitureManager.Instance.CurrentFurniture(prefabToInstaniate);
                    TapToPlace.placeNewFurniture = true;
                    //FurnitureManager.Instance.AddFurniture(prefabToInstaniate);
                });
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}