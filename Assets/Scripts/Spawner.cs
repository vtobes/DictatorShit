using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject objectToSpawn;
    GameObject newObject;

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        newObject = Instantiate(objectToSpawn);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        newObject.transform.position = ray.origin + new Vector3(0, 0, newObject.transform.position.z - ray.origin.z); ;
    }
}
