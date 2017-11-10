using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickWorld.Controllers
{

    // multiple seleciton manager
    public class SelectionManager : MonoBehaviour
    {

        // denotes whether the user is in selection mode
        private bool selectingOn;
        // list of selected game objects
        private LinkedList<GameObject> selection;

        public bool SelectingOn
        {
            get
            {
                return selectingOn;
            }

            set
            {
                selectingOn = value;
            }
        }

        // called when a gameoject is selected
        public bool OnObjectSelected(GameObject gameObject)
        {
            // if multiple selection mode is on
            if (selectingOn)
            {
                if (selection.Contains(gameObject))
                {
                    // if gameobject is part of the selection, remove it
                    selection.Remove(gameObject);
                    return true;
                }
                else
                {
                    // if gameobject is not part of the selection, add it
                    selection.AddFirst(gameObject);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Use this for initialization
        void Start()
        {
            // set multiple selection mode to false
            selectingOn = true;
            selection = new LinkedList<GameObject>();
            Debug.Log("selection manager");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}