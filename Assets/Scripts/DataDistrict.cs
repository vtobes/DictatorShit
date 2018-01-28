using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDistrict {

    public int hacker = 0;
    public int speecher = 0;
    public int spy = 0;
    public int victories=0;
    public int defeats= 0;
    public bool infiltrado = false;
    public Enumdata.Influence Difficult = Enumdata.Influence.hard;

    public float CurrectSuccess = 0.00f;
    public Enumdata.MissionType Mission = Enumdata.MissionType.rescue;

    public int MaxAgents = 0;

    public DataDistrict()
    {
      
    }
}
