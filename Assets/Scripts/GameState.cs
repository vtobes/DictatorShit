using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public int numAfiliados = 0;
    public int numPoblacion = 0;
    public int Speechbox = 0;
    public int Spybox =0;
    public int hackerbox = 0;
    public int Basedifficulty = 12;

    // Use this for initialization
    void Start () {
        GameMngr.Instance.setnumAfiliados(numAfiliados);
        GameMngr.Instance.setnumPoblacion(numPoblacion);
        GameMngr.Instance.setBasedifficulty(Basedifficulty);

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
