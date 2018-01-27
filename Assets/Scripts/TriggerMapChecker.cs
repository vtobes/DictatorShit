using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMapChecker : MonoBehaviour {


    public GameObject[] AttachPositions;
    Map_manager mapManager;

    // Use this for initialization
    void Start() {
    }
	
	// Update is called once per frame
	void Update () {
	}



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ha entrado");
        //mapManager.currentMap = gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Ha salido");
        //mapManager.currentMap = null;
    }

}
