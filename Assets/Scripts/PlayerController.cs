using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    Vector3 newPosition;
    bool isMoving;
    bool alreadyTurned;
    Vector3 auxPos;
    Ray ray;

    public GameObject player;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        newPosition = transform.position;
        isMoving = false;
        alreadyTurned = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            Flip();
            alreadyTurned = true;
        }
        else if (newPosition.x < transform.position.x && alreadyTurned == true)
        {
            Flip();
            alreadyTurned = false;
        }
        isMoving = true;
    }

    void Move()
    {
        anim.SetBool("isWalking", true);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 1.5f * Time.deltaTime);
        //auxPos = ray.origin + new Vector3(0, 0, transform.position.z - ray.origin.z);
        //rb.MovePosition(auxPos * 5.0f * Time.deltaTime);
        if (transform.position == newPosition)
        {
            StopWalking();
        }
    }

    public void Flip()
    {
        Vector3 flipper = new Vector3(-1, 1, 1);
        player.transform.localScale = Vector3.Scale(player.transform.localScale, flipper);
    }

    public void StopWalking()
    {
        isMoving = false;
        anim.SetBool("isWalking", false);
    }

}

