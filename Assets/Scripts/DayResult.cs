using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayResult : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Exito()
    {
        

        float exito_total = 100;
        
        for (int i = 0; i < GameMngr.Instance.GetDataDistric().Length; i++)
        {
            DataDistrict Ddistrict = GameMngr.Instance.GetDataDistric()[i];
            float fallo_base = GameMngr.Instance.getBasedifficulty();
            //correcion base por difcultad
            switch (Ddistrict.Difficult)
            {
                case Enumdata.Influence.easy:
                    fallo_base = GameMngr.Instance.getBasedifficulty();
                    break;
                case Enumdata.Influence.average:
                    fallo_base *= 2;
                    break;
                case Enumdata.Influence.hard:
                    fallo_base *= 3;
                    break;
                default:
                    break;
            }
            // calculo de colocacion correcta
            float bonus_colocacion_correcta, colocados;

            switch (GameMngr.Instance.GetDataDistric()[i].Mission)
            {

                case Enumdata.MissionType.rescue:
                    //(GameMngr.Instance.GetDataDistric()[i].hacker);
                    break;
                case Enumdata.MissionType.inflitration:
                    break;
                case Enumdata.MissionType.propaganda:
                    break;
            }
        }
    
       
    }
}
