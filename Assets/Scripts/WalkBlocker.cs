using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBlocker : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerController>().StopWalking();
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        player.GetComponent<PlayerController>().StopWalking();
    }
}
