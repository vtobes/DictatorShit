﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigating : MonoBehaviour {


    Vector3 newPosition;

	// Use this for initialization
	void Start () {
        newPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                transform.position = newPosition;
            }
        }
	}
}
