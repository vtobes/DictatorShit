using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour {

    public int maxPutPositions;
    public GameObject[] attachPositions;
    private int _currentPosition=0;
    Map_manager mapManager;

    public GameObject[] AttachPositions
    {
        get
        {
            return attachPositions;
        }

        set
        {
            attachPositions = value;
        }
    }

    public int CurrentPosition
    {
        get
        {
            return _currentPosition;
        }

        set
        {
            _currentPosition = value;
        }
    }

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
