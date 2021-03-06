﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCanvasResult : MonoBehaviour {

    public Text[] textsToFill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        if(textsToFill.Length == 16)
        {
            textsToFill[0].text = (GameMngr.Instance.AfiliateNumber - GameMngr.Instance.PreviousAffiliateNumber).ToString();
            textsToFill[1].text = GameMngr.Instance.AfiliateNumber.ToString();
            textsToFill[2].text = GameMngr.Instance.SuccessMissions.ToString();
            textsToFill[3].text = GameMngr.Instance.FailedMissions.ToString();
            textsToFill[4].text = GameMngr.Instance.AgentsGained.ToString();
            textsToFill[5].text = GameMngr.Instance.AgentsLost.ToString();
            textsToFill[6].text = GetInfluence(GameMngr.Instance.GetDataDistric()[0].Difficult.ToString());
            textsToFill[7].text = GetInfluence(GameMngr.Instance.GetDataDistric()[1].Difficult.ToString());
            textsToFill[8].text = GetInfluence(GameMngr.Instance.GetDataDistric()[2].Difficult.ToString());
            textsToFill[9].text = GetInfluence(GameMngr.Instance.GetDataDistric()[3].Difficult.ToString());
            textsToFill[10].text = GetInfluence(GameMngr.Instance.GetDataDistric()[4].Difficult.ToString());
            textsToFill[11].text = GetInfluence(GameMngr.Instance.GetDataDistric()[5].Difficult.ToString());
            textsToFill[12].text = GetInfluence(GameMngr.Instance.GetDataDistric()[6].Difficult.ToString());
            textsToFill[13].text = GetInfluence(GameMngr.Instance.GetDataDistric()[7].Difficult.ToString());
            textsToFill[14].text = GetInfluence(GameMngr.Instance.GetDataDistric()[8].Difficult.ToString());
            textsToFill[15].text = GetInfluence(GameMngr.Instance.GetDataDistric()[9].Difficult.ToString());
        }
    }

    string GetInfluence(string difficulty)
    {
        if(difficulty == "easy"){
            return "high";
        }else if (difficulty == "average")
        {
            return "medium";
        }
        else if (difficulty == "hard")
        {
            return "low";
        }
        return "";
    }
}
