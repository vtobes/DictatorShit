﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour {

    private int maxPutPositions;


    Map_manager mapManager;
    public Enumdata.Influence influence;
    public Enumdata.MissionType missionType;

    public GameObject[] attachPositions;
    public GameObject[] AttachPositions
    {
        get
        {
            return attachPositions;
        }

        set
        {
            attachPositions = value;
        }
    }
    
    private int _currentPosition = 0;
    public int CurrentPosition
    {
        get
        {
            return _currentPosition;
        }

        set
        {
            _currentPosition = value;
        }
    }

    public int MaxPutPositions
    {
        get
        {
            return maxPutPositions;
        }

        set
        {
            maxPutPositions = value;
        }
    }

    int speecherCount;
    int hackerCount;
    int spyCount;

    // Use this for initialization
    void Start() {
        MaxPutPositions = 0;
        GameObject gameManager = GameObject.Find("GameManager");
        mapManager = gameManager.GetComponent<Map_manager>();
        speecherCount = 0;
        hackerCount = 0;
        spyCount = 0;

        inicializePositions(missionType);
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Numero de Oradores:");
        Debug.Log(speecherCount);
        Debug.Log("Numero de Hackers:");
        Debug.Log(hackerCount);
        Debug.Log("Numero de Espias:");
        Debug.Log(spyCount);
    }

    private void inicializePositions(Enumdata.MissionType missionType)
    {
        switch (missionType)
        {
            case Enumdata.MissionType.inflitration:
                attachPositions = new GameObject[1];
               
               
               
                attachPositions[0] = Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity) ;
                break;

            case Enumdata.MissionType.propaganda:
                attachPositions = new GameObject[3];
                attachPositions[0]= Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity); 
                attachPositions[1] = Instantiate(new GameObject(), new Vector3(-2.52f, 0, -2.91f), Quaternion.identity); 
                attachPositions[2] = Instantiate(new GameObject(), new Vector3(2.48f, 0, 2.03f), Quaternion.identity); 
                break;

            case Enumdata.MissionType.rescue:
                attachPositions = new GameObject[3];
                attachPositions[0] = Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity);
                attachPositions[1] = Instantiate(new GameObject(), new Vector3(-2.52f, 0, -2.91f), Quaternion.identity);
                attachPositions[2] = Instantiate(new GameObject(), new Vector3(2.48f, 0, 2.03f), Quaternion.identity);
                break;

            default: break;
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        mapManager.CurrentMap = gameObject;
        mapManager.PutPositions = AttachPositions;
    }

    private void OnTriggerExit(Collider other)
    {
        mapManager.CurrentMap = null;
        mapManager.PutPositions = null;
    }

    public void incrementAgent(AgentInfo ai)
    {
        switch (ai.agenttype)
        {
            case Enumdata.AgentType.hacker:
                hackerCount++;
                break;

            case Enumdata.AgentType.speecher:
                speecherCount++;
                break;

            case Enumdata.AgentType.spy:
                spyCount++;
                break;
        }

    }

}
