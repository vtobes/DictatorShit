using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_manager : MonoBehaviour {

    public Text affText;
    public Text troopsText;

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

        affText.text = GameMngr.Instance.AfiliateNumber.ToString();
        troopsText.text = GameMngr.Instance.MaxTroops.ToString();
    }
}
