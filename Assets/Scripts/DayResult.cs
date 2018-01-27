using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayResult : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

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
                float bonus_colocacion_correcta, colocados=0;
                float max_agents = Ddistrict.MaxAgents;

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
                    //default:
                    //    colocados = 0;
                    //    break;
                }

                bonus_colocacion_correcta = fallo_base - (colocados * fallo_base);

                float segundafase = fallo_base * (1 - ((Ddistrict.speecher + Ddistrict.spy + Ddistrict.hacker) / max_agents));

                float exito = exito_total - bonus_colocacion_correcta - segundafase;
                Ddistrict.CurrectSuccess = exito;

                if (Ddistrict.infiltrado)
                    Ddistrict.CurrectSuccess += 10;

                //calcular si hay victoria
                float result = Random.Range(0.0f, 100.0f);
                if (result <= Ddistrict.CurrectSuccess)
                {
                    //vistoriaaa
                    Success(i);
                }
                else
                {
                    //derrota
                    Defeat(i);
                }



            }
            else
                Ddistrict.CurrectSuccess = 0;


        }
        GameMngr.Instance.GetDataDistric();
        Debug.Log("holaaaaaaa");

    }



    public void Success(int index)
    {
        if (GameMngr.Instance.GetDataDistric()[index].Mission == Enumdata.MissionType.propaganda ||
            GameMngr.Instance.GetDataDistric()[index].Mission == Enumdata.MissionType.rescue)
        {
            GameMngr.Instance.GetDataDistric()[index].infiltrado = false;

            float troopBoost = Random.Range(0.0f, 100.0f);
            if(troopBoost <= 20.0f)
            {
                GameMngr.Instance.MaxTroops++;
            }
        }
        else
        {
            GameMngr.Instance.GetDataDistric()[index].infiltrado = true;
        }
        GameMngr.Instance.GetDataDistric()[index].victories++;
        GameMngr.Instance.TotalPopulation += 1000;
        if(GameMngr.Instance.GetDataDistric()[index].victories % 3 == 0)
        {
            if(GameMngr.Instance.GetDataDistric()[index].Difficult != Enumdata.Influence.easy)
            {
                GameMngr.Instance.GetDataDistric()[index].Difficult--;
            }
        }
    }
    public void Defeat(int i)
    {
        DataDistrict Ddistrict = GameMngr.Instance.GetDataDistric()[i];
        //eliminar 1 tropa del general
        GameMngr.Instance.MaxTroops--;
        //Regresar las tropas restantes

        //aumenta derrota
        Ddistrict.defeats++;
        //- 500 poblacion
        GameMngr.Instance.AfiliateNumber -= 500;
        // añadi penalizacion de tres derrotas?

    }
}
