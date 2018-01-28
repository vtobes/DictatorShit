using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayResult : MonoBehaviour {

    public GameObject[] DistrictList;
    private int num_defeats= 0;
    public GameObject Panel_victoria;
    public GameObject Panel_derrrota;
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
                float bonus_colocacion_correcta, colocados = 0;
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

                //Devolver tropas
                GameMngr.Instance.MaxTroops += GameMngr.Instance.GetDataDistric()[i].speecher + GameMngr.Instance.GetDataDistric()[i].spy + GameMngr.Instance.GetDataDistric()[i].hacker;

            }
            else
                Ddistrict.CurrectSuccess = 0;


        }
        GameMngr.Instance.GetDataDistric();


    }



    public void Success(int index)
    {
        if (GameMngr.Instance.GetDataDistric()[index].Mission == Enumdata.MissionType.propaganda ||
            GameMngr.Instance.GetDataDistric()[index].Mission == Enumdata.MissionType.rescue)
        {
            GameMngr.Instance.GetDataDistric()[index].infiltrado = false;

            float troopBoost = Random.Range(0.0f, 100.0f);
            if (troopBoost <= 20.0f)
            {
                GameMngr.Instance.MaxTroops++;
                //Auxiliar data for results
                GameMngr.Instance.AgentsGained++;
            }
        }
        else
        {
            GameMngr.Instance.GetDataDistric()[index].infiltrado = true;
        }
        GameMngr.Instance.GetDataDistric()[index].victories++;
        //Auxiliar data for results
        GameMngr.Instance.PreviousAfiliateNumber = GameMngr.Instance.AfiliateNumber;

        GameMngr.Instance.AfiliateNumber += 1000;
      
        if (GameMngr.Instance.GetDataDistric()[index].victories % 3 == 0)
        {
            if (GameMngr.Instance.GetDataDistric()[index].Difficult != Enumdata.Influence.easy)
            {
                GameMngr.Instance.GetDataDistric()[index].Difficult--;
            }
        }
        //Auxiliar data for results
        GameMngr.Instance.SuccessMissions++;

        // procesar victoria
        if (GameMngr.Instance.AfiliateNumber > ((GameMngr.Instance.TotalPopulation / 2) + 1))
        {
            // carcar canas victoria
            Panel_victoria.SetActive(true);
        }



    }
    public void Defeat(int i)
    {
        DataDistrict Ddistrict = GameMngr.Instance.GetDataDistric()[i];
        //eliminar 1 tropa del general
        GameMngr.Instance.MaxTroops--;
        //Auxiliar data for results
        GameMngr.Instance.AgentsLost++;
        //Regresar las tropas restantes
        GameMngr.Instance.GetDataDistric()[i].infiltrado = false;
        //aumenta derrota
        Ddistrict.defeats++;
        //Auxiliar data for results
        GameMngr.Instance.PreviousAfiliateNumber = GameMngr.Instance.AfiliateNumber;
        //- 500 poblacion
        GameMngr.Instance.AfiliateNumber -= 500;
        //Auxiliar data for results
        GameMngr.Instance.FailedMissions++;

        if ((num_defeats > 25)|| (GameMngr.Instance.AfiliateNumber<=0))
        {
            Panel_derrrota.SetActive(true);
        }
        

    }

    public void UpdateDistrict()
    {
        for (int i = 0; i < DistrictList.Length; i++)
        {
            //reseteamos y actualizamos el district
            DistrictList[i].GetComponent<District>().SpeecherCount = 0;
            DistrictList[i].GetComponent<District>().SpyCount = 0;
            DistrictList[i].GetComponent<District>().HackerCount = 0;
            // dificultad
            GameMngr.Instance.GetDataDistric()[i].Difficult = DistrictList[i].GetComponent<District>().influence;
            DistrictList[i].GetComponent<District>().missionType = (Enumdata.MissionType)Random.Range(0, 2);
            GameMngr.Instance.GetDataDistric()[i].Mission = DistrictList[i].GetComponent<District>().missionType;
            DistrictList[i].GetComponent<District>().inicializePositions(DistrictList[i].GetComponent<District>().missionType);
        }

        // eliminar piezas colocadas
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Colocadas");

        foreach (GameObject respawn in respawns)
        {
            DestroyObject(respawn);
        }
    }

    public void ResetDataDistric()
    {
        for (int i = 0; i < GameMngr.Instance.GetDataDistric().Length; i++)
        {
            GameMngr.Instance.GetDataDistric()[i].speecher = 0;
            GameMngr.Instance.GetDataDistric()[i].spy = 0;
            GameMngr.Instance.GetDataDistric()[i].hacker = 0;

        }
    }
}
