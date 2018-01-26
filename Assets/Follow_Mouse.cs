using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.origin + new Vector3(0, 0, 5);

    }
    private void OnMouseUp()
    {
        Debug.Log("seleccionador");
    }
}
