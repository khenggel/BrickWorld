using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;

public class SaveAsPrefab : MonoBehaviour {

    // global id to ensure each model saved has a different name
    // TODO: serialisation issue
    private static int latestModelID = 0;

    // executed when the object is clicked
    public void saveThisToLibrary()
    {
        // define the local address the object is to be saved to
        string localAddress = "Assets/View/Models/item" + latestModelID + ".prefab";
        // save as prefab
        PrefabUtility.CreatePrefab(localAddress, this.gameObject);
        // update id
        latestModelID += 1;
        // log
        // TODO return message
        Debug.Log("Saved: " + localAddress);
    }

}
