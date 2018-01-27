using UnityEngine;
using System.Collections;
//using System.Runtime.InteropServices;

public class GameMngr : MonoBehaviour
{
    private static GameMngr game_instance;

    //Variables
    private static DataDistrict[] DataDistrict = new DataDistrict[10];
    private static string nextScene = "";
    private static string lastDance = "";
    private static string currentKeyScene = "015";

    private int numAfiliados = 0;
    private int numPoblacion = 0;

    private int Basedifficulty = 12;




    public static GameMngr Instance
    {
        get
        {
            if (game_instance == null)
            {
                //For access to this GameObject must be used GameManagerObject.Instance.MethodName()...
                GameObject gameManagerObject = new GameObject("GameManagerObject");
                DontDestroyOnLoad(gameManagerObject);

                game_instance = gameManagerObject.AddComponent<GameMngr>();
                Debug.Log("Se ha creado una instancia del GameMngr");
                for(int i = 0; i < 10; i++)
                {
                    DataDistrict[i] = new DataDistrict();
                 
                }

            }

            return game_instance;
        }
    }



    public string getNextSceneToLoad()
    {
        return nextScene;
    }

    public void setNextSceneToLoad(string name)
    {
        nextScene = name;
    }

    public string getLastDance()
    {
        return lastDance;
    }

    public void setLastDance(string name)
    {
        lastDance = name;
    }

    public string getCurrentKeyScene()
    {
        return currentKeyScene;
    }

    public void setCurrentKeyScene(string key)
    {
        currentKeyScene = key;
    }

    public void setDataDistrict(int district, DataDistrict data)
    {
        DataDistrict[district] = data;
    }

    public DataDistrict[] GetDataDistric()
    {
        return DataDistrict;
    }

    public int getnumAfiliados()
    {
        return numAfiliados;
    }

    public void setnumAfiliados(int num)
    {
        numAfiliados = num;
    }

    public int getnumPoblacion()
    {
        return numPoblacion;
    }

    public void setnumPoblacion(int num)
    {
        numAfiliados = num;
    }

    public int getBasedifficulty()
    {
        return Basedifficulty;
    }

    public void setBasedifficulty(int num)
    {
        Basedifficulty = num;
    }
}