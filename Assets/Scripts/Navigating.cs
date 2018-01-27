using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigating : MonoBehaviour {


    Vector3 newPosition;
    bool isMoving;
    bool alreadyTurned;
    Vector3 auxPos;
    Ray ray;

    // Use this for initialization
    void Start () {
        newPosition = transform.position;
        isMoving = false;
        alreadyTurned = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SetPosition();
            
        }

        if (isMoving)
        {
            Move();
        }
	}

    void SetPosition()
    {
        Plane plane = new Plane(Vector3.forward, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point;
        if (plane.Raycast(ray, out point))
        {
            auxPos = ray.GetPoint(point);
            newPosition = new Vector3(auxPos.x, transform.position.y, transform.position.z);
        }
        if (newPosition.x > transform.position.x && alreadyTurned == false)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            alreadyTurned = true;
        } else if (newPosition.x < transform.position.x && alreadyTurned == true)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            alreadyTurned = false;
        }
        isMoving = true;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 5.0f * Time.deltaTime);
        //auxPos = ray.origin + new Vector3(0, 0, transform.position.z - ray.origin.z);
        //rb.MovePosition(auxPos * 5.0f * Time.deltaTime);
        if(transform.position == newPosition)
        {
            isMoving = false;
        }
    }
}
