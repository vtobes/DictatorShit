using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public int numAfiliados = 1000;
    public int numPoblacion = 0;
    public int Speechbox = 0;
    public int Spybox =0;
    public int hackerbox = 0;
    public int Basedifficulty = 12;
    
    public int maxTroops = 10;

    
    // Use this for initialization
    void Start () {
        //GameMngr.Instance.setnumAfiliados(numAfiliados);
        GameMngr.Instance.AfiliateNumber = numAfiliados;
        GameMngr.Instance.setnumPoblacion(numPoblacion);
        GameMngr.Instance.setBasedifficulty(Basedifficulty);
        GameMngr.Instance.setMaxTroops(maxTroops);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
