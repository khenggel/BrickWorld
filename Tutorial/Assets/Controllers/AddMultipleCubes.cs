using HoloToolkit.Examples.Prototyping;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;

namespace BrickWorld.Controllers
{

    public class AddMultipleCubes : MonoBehaviour
    {
        public GameObject manager;
        private GameObject view;
        private static int latestID = 0;

        // Use this for initialization
        void Start()
        {

        }

        private void OnMouseUp()
        {
            // create variables
            view = manager.GetComponent<AppController>().view;
            GameObject mainMenu = view.transform.Find("MainMenu(Clone)").gameObject;

            // create new cube object and set it up
            GameObject newCube = Instantiate(Resources.Load("Cube") as GameObject);
            newCube.transform.position = mainMenu.transform.position;
            newCube.transform.rotation = mainMenu.transform.rotation;
            newCube.transform.SetParent(view.transform, true);

            // set up its SetMenu script
            newCube.GetComponent<SetMenu>().Target = mainMenu;
            newCube.GetComponent<SetMenu>().manager = manager;
            newCube.GetComponent<CubeController>().manager = manager;

            // set up its movewithobject script
            MoveWithObject newobject = newCube.GetComponent<MoveWithObject>();
            newobject.ReferenceObject = view.transform.Find("HoloLensCamera").gameObject;
            newobject.StartRunning();


            // save cube as prefab
            string localAddress = "Assets/View/Models/cube" + latestID + ".prefab";
            PrefabUtility.CreatePrefab(localAddress, newCube);
            latestID += 1;
            Debug.Log("Saved: " + localAddress);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}