using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_manager : MonoBehaviour {
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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
