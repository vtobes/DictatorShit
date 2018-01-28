using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public Transform playerTP;
    public GameObject player;

    public Transform camTP;

    public GameObject cam;

    BoxCollider box;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Door Encountered!");
        player.GetComponent<PlayerController>().StopWalking();
        player.transform.position = playerTP.position;

        cam.transform.position = camTP.position;

    }
}
