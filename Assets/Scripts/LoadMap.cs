using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour {

    public GameObject canvas;
    bool canLoadMap;
	// Use this for initialization
	void Start () {
        canLoadMap = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (canLoadMap)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadMapScene();
            }
        }
	}

    void OnTriggerEnter()
    {
        canvas.SetActive(true);
        canLoadMap = true;
    }

    void OnTriggerExit()
    {
        canvas.SetActive(false);
        canLoadMap = false;
    }

    void LoadMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }

    
}
