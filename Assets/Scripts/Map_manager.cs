using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_manager : MonoBehaviour {

    
    GameObject[] _PutPositions;
    public GameObject[] PutPositions
    {
        get
        {
            return _PutPositions;
        }

        set
        {
            _PutPositions = value;
        }
    }

    GameObject _CurrectMap;
    public GameObject CurrentMap
    {
        get
        {
            return _CurrectMap;
        }

        set
        {
            _CurrectMap = value;
        }
    }

    

    // Use this for initialization
    void Start () {
		    GameMngr.Instance.getCurrentKeyScene();
	}
	
	// Update is called once per frame
	void Update () {
		    if(CurrentMap != null)
        {
            Debug.Log(CurrentMap.name);
        }
	}
}
