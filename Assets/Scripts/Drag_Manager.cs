using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Manager : MonoBehaviour {


    GameObject _ObjectDragged = null;


    Ray ray;

    public GameObject ObjectDragged
    {
        get
        {
            return _ObjectDragged;
        }

        set
        {
            _ObjectDragged = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePositionObjectDraggedToMap();
        ManageDrag();

    }

    private void ManageDrag()
    {
        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 8000))
            {
                if(hit.transform.gameObject.tag == "Movable")
                {
                    _ObjectDragged = hit.transform.gameObject;
                }
            }

            if(_ObjectDragged != null )
                _ObjectDragged.transform.position = ray.origin + new Vector3(0, 0,_ObjectDragged.transform.position.z - ray.origin.z);

        }
        else
        {
            _ObjectDragged = null;
        }
    }
 

    private void MovePositionObjectDraggedToMap()
    {
        Map_manager map = GetComponent<Map_manager>();
        if (Input.GetMouseButtonUp(0))
        {
            if ((_ObjectDragged != null) && (map.CurrentMap != null))
            {
                int num_positions = map.CurrentMap.GetComponent<District>().CurrentPosition;
                //checkear si puedes añadir tropas
                if (num_positions < map.CurrentMap.GetComponent<District>().MaxPutPositions )
               
                {
                    //colocar tropa
                    _ObjectDragged.transform.position = map.CurrentMap.GetComponent<District>().AttachPositions[num_positions].transform.position;
                    //aumentar numero de tropa
                    _ObjectDragged.tag = "Untagged";
                    map.CurrentMap.GetComponent<District>().CurrentPosition++;
                    //Identificar agente
                    AgentInfo agentInfo = _ObjectDragged.GetComponent<AgentInfo>();

                    //Aumentar el contador en distrito
                    map.CurrentMap.GetComponent<District>().incrementAgent(agentInfo);


                    DataDistrict Ddistrict = GameMngr.Instance.GetDataDistric()[map.CurrentMap.GetComponent<District>().IdDistrict];
                    Ddistrict.hacker = map.CurrentMap.GetComponent<District>().HackerCount;
                    Ddistrict.spy = map.CurrentMap.GetComponent<District>().SpyCount;
                    Ddistrict.speecher = map.CurrentMap.GetComponent<District>().SpeecherCount;
                    //GameMngr.Instance.setDataDistrict(map.CurrentMap.GetComponent<District>().IdDistrict, new DataDistrict();

                    DataDistrict Dddistrict = GameMngr.Instance.GetDataDistric()[map.CurrentMap.GetComponent<District>().IdDistrict];

                    Debug.Log("numero de agentes: "+ GameMngr.Instance.GetDataDistric()[map.CurrentMap.GetComponent<District>().IdDistrict]);
                }

                //TODO: destruir tropa
            }
        }
    }

    private void OnMouseDrag()
    {
       

    }
    private void OnMouseDown()
    {
       
    }
   
}
