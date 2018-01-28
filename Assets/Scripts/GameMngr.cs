
using UnityEngine;
using System.Collections;

//using System.Runtime.InteropServices;

public class GameMngr : MonoBehaviour
{

    


    private int previousAffiliateNumber;

    public int PreviousAffiliateNumber
    {
        get
        {
            return previousAffiliateNumber;
        }

        set
        {
            previousAffiliateNumber = value;
        }
    }

    private int agentsGained;

    public int AgentsGained
    {
        get
        {
            return agentsGained;
        }

        set
        {
            agentsGained = value;
        }
    }

    private int agentsLost;

    public int AgentsLost
    {
        get
        {
            return agentsLost;
        }
        set
        {
            agentsLost = value;
        }
    }


    private int successMissions;

    public int SuccessMissions
    {
        get
        {
            return successMissions;
        }

        set
        {
            successMissions = value;
        }
    }

    private int failedMissions;


    public int FailedMissions
    {
        get
        {
            return failedMissions;
        }

        set
        {
            failedMissions = value;
        }
    }

    [SerializeField]
    private int maxTroops;

    public int MaxTroops
    {
        get
        {
            return maxTroops;
        }

        set
        {
            maxTroops = value;
        }
    }

    private int totalPopulation;

    public int TotalPopulation
    {
        get
        {
            return totalPopulation;
        }

        set
        {
            totalPopulation = value;
        }
    }


    private int afiliateNumber;

    public int AfiliateNumber
    {
        get
        {
            return afiliateNumber;
        }

        set
        {
            afiliateNumber = value;
        }
    }

    private int previousAfiliateNumber;

    public int PreviousAfiliateNumber
    {
        get
        {
            return previousAfiliateNumber;
        }

        set
        {
            previousAfiliateNumber = value;
        }
    }


    private static GameMngr game_instance;

    //Variables
    private static DataDistrict[] DataDistrict = new DataDistrict[10];
    private static string nextScene = "";
    private static string lastDance = "";
    private static string currentKeyScene = "015";
    private static bool alreadyInitialized = false;
    private int numAfiliados = 0;
    private int numPoblacion = 0;

    private int Basedifficulty = 12;




    public static GameMngr Instance
    {
        get
        {
            if (game_instance == null)
            {
                alreadyInitialized = false;
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



    public int getBasedifficulty()
    {
        return Basedifficulty;
    }

    public void setBasedifficulty(int num)
    {
        Basedifficulty = num;
    }

    public void setMaxTroops(int num)
    {
        maxTroops = num;
    }

    public int getMaxTroops()
    {
        return maxTroops;
    }

    public void setAlreadyInitialized(bool value)
    {
        alreadyInitialized = value;
    }

    public bool getAlreadyInitialized()
    {
        return alreadyInitialized;
    }
}