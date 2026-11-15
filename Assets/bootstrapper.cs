using JetBrains.Annotations;
using UnityEngine;

public class bootstrapper : MonoBehaviour
{

    public GameObject GameManagerPrefab;
    public GameObject LevelManagerPrefab;
    public GameObject GameStateManagerPrefab;
    public GameObject UIManagerPrefab;

    void Start()
    {
        if(GameManager.instance == null)
        {
            Instantiate(GameManagerPrefab);
        }
        //sets manager instances if not already set, creats manager as well if it does not exist, and insures they are children of the game manager
        if(GameManager.instance.levelManager == null)
        {
            if (!FindAnyObjectByType<LevelManager>())
            {
                Instantiate(LevelManagerPrefab);
            }
            GameManager.instance.levelManager = FindAnyObjectByType<LevelManager>();
            GameManager.instance.levelManager.transform.parent = GameManager.instance.transform;
        }
        
        if (GameManager.instance.uIManger == null)
        {
            if (!FindAnyObjectByType<UIManger>())
            {
                Instantiate(UIManagerPrefab);
            }
            GameManager.instance.uIManger = FindAnyObjectByType<UIManger>();
            GameManager.instance.uIManger.transform.parent = GameManager.instance.transform;
        }
        
        if (GameManager.instance.gameStateManager == null)
        {
            if (!FindAnyObjectByType<GameStateMnager>())
            {
                Instantiate(GameStateManagerPrefab);
            }
            GameManager.instance.gameStateManager = FindAnyObjectByType<GameStateMnager>();
            GameManager.instance.gameStateManager.transform.parent = GameManager.instance.transform;
        }

        //set up after Ui and level Manager as both will be needed for start functions, other managers do not rely on eachother on start up if at all
        GameManager.instance.gameStateManager.SetUp();
    }

    
}
