using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infomation_point : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
   
        Debug.Log("Position: "+ ray.direction.ToString());

    }
}
