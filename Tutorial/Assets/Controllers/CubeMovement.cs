using HoloToolkit.Examples.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickWorld.Controllers
{

    public class CubeMovement : MonoBehaviour
    {

        public GameObject searchTarget;
        public GameObject reference;

        // Use this for initialization
        void Start()
        {
            object[] obj = FindObjectsOfType(searchTarget.GetType());
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;
                //Debug.Log(g.name);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}