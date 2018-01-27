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

    public void CheckSuccess()
    {
        

        float exito_total = 100;

        for (int i = 0; i < GameMngr.Instance.GetDataDistric().Length; i++)
        {
            DataDistrict Ddistrict = GameMngr.Instance.GetDataDistric()[i];
            if ((Ddistrict.speecher + Ddistrict.spy + Ddistrict.hacker) > 0)
            {


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
                int max_agents = Ddistrict.MaxAgents;

                switch (GameMngr.Instance.GetDataDistric()[i].Mission)
                {

                    case Enumdata.MissionType.rescue:
                        colocados = Ddistrict.hacker / max_agents;

                        break;
                    case Enumdata.MissionType.inflitration:
                        colocados = Ddistrict.spy / max_agents;

                        break;
                    case Enumdata.MissionType.propaganda:
                        colocados = Ddistrict.speecher / max_agents;

                        break;
                    default:
                        colocados = 0;
                        break;
                }

                bonus_colocacion_correcta = fallo_base - (colocados * fallo_base);

                float segundafase = fallo_base * (1 - ((Ddistrict.speecher + Ddistrict.spy + Ddistrict.hacker) / max_agents));

                float exito = exito_total - bonus_colocacion_correcta - segundafase;            
                Ddistrict.CurrectSuccess = exito;

                if (Ddistrict.infiltrado)
                    Ddistrict.CurrectSuccess += 10;

                //calcular si hay victoria
                float result = Random.Range(0.0f, 100.0f);
                if(result <= Ddistrict.CurrectSuccess)
                {
                    //vistoriaaa
                }
                else
                {
                    //derrota
                }



            }
            else
                Ddistrict.CurrectSuccess = 0;


        }
    
       
    }

    public void Defeat()
    {

    }
}
