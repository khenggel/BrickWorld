using BrickWorld.EventSystems;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BrickWorld.Controllers
{
       
    // class description goes here
    public class CubeController : BaseScript, IInputClickHandler, IFocusable
    {
        private bool isInMultipleSelection;
        private int id;

        // selection action
        Func<GameObject, bool> cbObjectSelected;

        public bool IsInMultipleSelection
        {
            get
            {
                return isInMultipleSelection;
            }

            set
            {
                isInMultipleSelection = value;
                // change appearance based on whether the cube is selected or not
                if (isInMultipleSelection)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log(": isSelected = " + isInMultipleSelection);
                } else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    Debug.Log("isSelected = " + isInMultipleSelection);
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            IsInMultipleSelection = false;

            // register object selected callbacks
            cbObjectSelected += manager.GetComponent<SelectionManager>().OnObjectSelected;

        }

        // Update is called once per frame
        void Update()
        {

        }

        // unused
        public void RegisterOnObjectSelectedCallback(Func<GameObject, bool> callback)
        {
            cbObjectSelected += callback;
        }
        
        // unused
        public void UnregisterOnObjectSelectedCallback(Func<GameObject, bool> callback)
        {
            cbObjectSelected -= callback;
        }

        // change cube color on mouse-over
        public void OnFocusEnter()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        public void OnFocusExit()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (cbObjectSelected != null)
            {
                IsInMultipleSelection = cbObjectSelected(this.gameObject);
            }
            else
            {
                throw new NullReferenceException("cbObjectSelected is null");
            }
        }
    }
}