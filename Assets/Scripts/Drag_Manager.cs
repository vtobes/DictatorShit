﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Manager : MonoBehaviour {


    GameObject _ObjectDragged = null;


    Ray ray;

    public GameObject ObjectDragged
    {
        get
        {
            return _ObjectDragged;
        }

        set
        {
            _ObjectDragged = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageDrag();

    }

    private void ManageDrag()
    {
        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 8000))
            {
<<<<<<< HEAD
                if(hit.transform.gameObject.tag == "Movable")
                {
                    _ObjectDragged = hit.transform.gameObject;
                }
                
=======
                if (hit.transform.gameObject.tag == "Movable") 
                _ObjectDragged = hit.transform.gameObject;
>>>>>>> origin/master

            }

            if(_ObjectDragged != null )
                _ObjectDragged.transform.position = ray.origin + new Vector3(0, 0,_ObjectDragged.transform.position.z - ray.origin.z);

        }
        else
        {
            _ObjectDragged = null;
        }
    }
 

    private void MovePositionObjectDraggedToMap()
    {
        Map_manager map = GetComponent<Map_manager>();
        if ((_ObjectDragged != null) && (map.CurrentMap!=null))
        {
            //checkear si puedes añadir tropas
            
            //colocar tropa

            //aumentar numero de tropa

        }
    }

    private void OnMouseDrag()
    {
       

    }
    private void OnMouseDown()
    {
       
    }
   
}
