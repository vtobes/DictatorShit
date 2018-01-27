using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMapChecker : MonoBehaviour {

    public int maxPutPositions;
    public GameObject[] AttachPositions;
    Map_manager mapManager;

    // Use this for initialization
    void Start() {
        maxPutPositions = 0;
        GameObject gameManager = GameObject.Find("GameManager");
        mapManager = gameManager.GetComponent<Map_manager>();
    }
	
	// Update is called once per frame
	void Update () {
	}



    private void OnTriggerEnter(Collider other)
    {
        mapManager.CurrentMap = gameObject;
        mapManager.PutPositions = AttachPositions;
    }

    private void OnTriggerExit(Collider other)
    {
        mapManager.CurrentMap = null;
        mapManager.PutPositions = null;
    }

}
