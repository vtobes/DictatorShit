using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    public void ResetDataValues()
    {
        
        GameMngr.Instance.SuccessMissions = 0;
        GameMngr.Instance.FailedMissions = 0;
        GameMngr.Instance.AgentsLost = 0;
        GameMngr.Instance.AgentsGained = 0;
    }
    
    
}
