﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour {

    private int maxPutPositions;


    Map_manager mapManager;
    public int IdDistrict;
    public Enumdata.Influence influence;
    public Enumdata.MissionType missionType;

    public GameObject rescueMission;
    public GameObject propagandaMission;
    public GameObject infiltrateMission;


    public GameObject highShade;
    public GameObject midShade;
    public GameObject lowShade;

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

    public int SpeecherCount
    {
        get
        {
            return speecherCount;
        }

        set
        {
            speecherCount = value;
        }
    }

    public int HackerCount
    {
        get
        {
            return hackerCount;
        }

        set
        {
            hackerCount = value;
        }
    }

    public int SpyCount
    {
        get
        {
            return spyCount;
        }

        set
        {
            spyCount = value;
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
        SpeecherCount = 0;
        HackerCount = 0;
        SpyCount = 0;

        if (GameMngr.Instance.getAlreadyInitialized())
        {
            influence = GameMngr.Instance.GetDataDistric()[IdDistrict].Difficult;
            missionType = GameMngr.Instance.GetDataDistric()[IdDistrict].Mission;
        }


        inicializePositions(missionType);

       
        
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Numero de Oradores:");
        Debug.Log(SpeecherCount);
        Debug.Log("Numero de Hackers:");
        Debug.Log(HackerCount);
        Debug.Log("Numero de Espias:");
        Debug.Log(SpyCount);


        if (missionType == Enumdata.MissionType.inflitration)
        {

            for(int i=0;i<attachPositions.Length ; i++)
            {
                if(i>0)attachPositions[i].SetActive(false);
            }
            propagandaMission.SetActive(false);
            rescueMission.SetActive(false);
            infiltrateMission.SetActive(true);
        }
        else if(missionType== Enumdata.MissionType.propaganda || missionType == Enumdata.MissionType.rescue)
        {

            for (int i = 0; i < attachPositions.Length; i++)
            {
                attachPositions[i].SetActive(true);
            }

            if (missionType == Enumdata.MissionType.propaganda)
            {
                propagandaMission.SetActive(true);
                rescueMission.SetActive(false);
                infiltrateMission.SetActive(false);
            }
            else
            {
                propagandaMission.SetActive(false);
                rescueMission.SetActive(true);
                infiltrateMission.SetActive(false);
            }

        }

        if(influence== Enumdata.Influence.easy) //FACIL
        {
            highShade.SetActive(false);
            midShade.SetActive(false);
            lowShade.SetActive(true);
        }else if(influence== Enumdata.Influence.average) //MEDIO
        {
            highShade.SetActive(false);
            midShade.SetActive(true);
            lowShade.SetActive(false);
        }
        else //DIFICIL
        {
            highShade.SetActive(true);
            midShade.SetActive(false);
            lowShade.SetActive(false);
        }
    }

    public void inicializePositions(Enumdata.MissionType missionType)
    {
        switch (missionType)
        {
            case Enumdata.MissionType.inflitration:
                //attachPositions = new GameObject[1];

                maxPutPositions = 1;

                //attachPositions[0] = Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity) ;
                break;

            case Enumdata.MissionType.propaganda:
                //attachPositions = new GameObject[3];
                //attachPositions[0]= Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity); 
                //attachPositions[1] = Instantiate(new GameObject(), new Vector3(-2.52f, 0, -2.91f), Quaternion.identity); 
                //attachPositions[2] = Instantiate(new GameObject(), new Vector3(2.48f, 3.11f, -2.03f), Quaternion.identity); 
                maxPutPositions = 3;
                break;
                
            case Enumdata.MissionType.rescue:
                //attachPositions = new GameObject[3];
                //attachPositions[0] = Instantiate(new GameObject(), new Vector3(2.7f, 0, -2.7f), Quaternion.identity);
                //attachPositions[1] = Instantiate(new GameObject(), new Vector3(-2.52f, 0, -2.91f), Quaternion.identity);
                //attachPositions[2] = Instantiate(new GameObject(), new Vector3(2.48f, 3.11f, -2.03f), Quaternion.identity);
                maxPutPositions = 3;
                break;

            default: break;
                
        }
        GameMngr.Instance.GetDataDistric()[IdDistrict].MaxAgents = maxPutPositions;
        GameMngr.Instance.GetDataDistric()[IdDistrict].Mission = missionType;
        GameMngr.Instance.GetDataDistric()[IdDistrict].Difficult = influence;
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
                HackerCount++;
                break;

            case Enumdata.AgentType.speecher:
                SpeecherCount++;
                break;

            case Enumdata.AgentType.spy:
                SpyCount++;
                break;
        }

    }

}
