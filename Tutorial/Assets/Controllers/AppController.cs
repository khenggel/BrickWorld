using Assets.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BrickWorld.Controllers
{

    public class AppController : MonoBehaviour
    {

        public GameObject manager;
        public GameObject view;
        public GameObject mainMenuPrefab;

        private GameObject eventSystemObj;
        private EventSystem eventSystem;

        private GameObject mainMenu;
        private World world;

        public GameObject EventSystem
        {
            get
            {
                return eventSystemObj;
            }
        }

        public EventSystem Es
        {
            get
            {
                return eventSystem;
            }
        }

        // Use this for initialization
        void Start()
        {
            world = new World();

            // create event system
            CreateEventSystem();

            // create main menu
            CreateMainMenu();

            // create seleciton manager
            CreateSelectionManager();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // still unused
        public void AddBrick(Transform transform)
        {
            Brick newBrick = new Brick(1, 1, 1, new List<Brick>(), transform);
            world.addBrick(newBrick);
        }

        // create selection manager
        private void CreateSelectionManager()
        {
            manager.AddComponent<SelectionManager>();
        }

        // just instantiate through this script instead of in unity
        private void CreateEventSystem()
        {
            eventSystemObj = new GameObject("EventSystem");
            eventSystemObj.transform.SetParent(manager.transform, true);
            eventSystem = eventSystemObj.AddComponent<EventSystem>();
            eventSystem.sendNavigationEvents = true;
            eventSystem.pixelDragThreshold = 5;
            StandaloneInputModule sim = eventSystemObj.AddComponent<StandaloneInputModule>();
            sim.horizontalAxis = "Horizontal";
            sim.verticalAxis = "Vertical";
            sim.submitButton = "Submit";
            sim.cancelButton = "Cancel";
            sim.inputActionsPerSecond = 10;
            sim.repeatDelay = 0.5f;
            sim.forceModuleActive = false;
        }

        // just instantiate from prefab (in this script instead of in unity)
        private void CreateMainMenu()
        {
            mainMenu = Instantiate(mainMenuPrefab, new Vector3(2, 3, 2), Quaternion.identity);
            mainMenu.transform.SetParent(view.transform, true);
            mainMenu.transform.Find("PlacementButton").gameObject.GetComponent<AddMultipleCubes>().manager = manager;
        }
    }
}