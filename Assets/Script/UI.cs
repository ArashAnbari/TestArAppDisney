using UnityEngine;

namespace AR
{
    public class UI : MonoBehaviour
    {
        //referencer
        [SerializeField]
        private GameObject startMenu, sceneMenu;
        

        public static bool menuOpen;
        public static int id;
        public static bool newFurniture = false;

        private void Update()
        {
            if (startMenu.activeInHierarchy) menuOpen = true; else menuOpen = false;
        }       

        private void Start()
        {
            startMenu.SetActive(true);
            sceneMenu.SetActive(false);

        }

        public void Quite()
        {
            Application.Quit();
        }
    }
}
