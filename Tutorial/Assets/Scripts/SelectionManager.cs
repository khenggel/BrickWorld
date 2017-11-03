using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    // denotes whether the user is in selection mode
    private bool selectingOn;
    // list of selected game objects
    private LinkedList<GameObject> selection;

    // Use this for initialization
    void Start () {
        selectingOn = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
