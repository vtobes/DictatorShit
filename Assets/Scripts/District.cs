using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour {

    private int maxPutPositions;


    Map_manager mapManager;
    public int IdDistrict;
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
    }

    private void inicializePositions(Enumdata.MissionType missionType)
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
