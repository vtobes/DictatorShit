using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public int numAfiliados;
    public int numPoblacion;
    public int Speechbox = 0;
    public int Spybox =0;
    public int hackerbox = 0;
    public int Basedifficulty;
    
    public int maxTroops = 10;

    
    // Use this for initialization
    void Start () {
        //GameMngr.Instance.setnumAfiliados(numAfiliados);
        if (!GameMngr.Instance.getAlreadyInitialized())
        {
            GameMngr.Instance.AfiliateNumber = numAfiliados;
            GameMngr.Instance.setnumPoblacion(numPoblacion);
            GameMngr.Instance.setBasedifficulty(Basedifficulty);
            GameMngr.Instance.setMaxTroops(maxTroops);
            GameMngr.Instance.setAlreadyInitialized(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
