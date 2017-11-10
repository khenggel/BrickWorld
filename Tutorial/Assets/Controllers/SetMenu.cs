using HoloToolkit.Examples.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickWorld.Controllers
{

    public class SetMenu : BaseScript
    {

        public GameObject Target;

        // Use this for initialization
        void Start()
        {

        }

        private void OnMouseUp()
        {
            // make menu reappear
            Target.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            Target.SetActive(true);
            this.GetComponent<MoveWithObject>().StopRunning();

            // create brick in the data model at the exact same position
            manager.GetComponent<AppController>().AddBrick(this.transform);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
