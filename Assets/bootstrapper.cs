using JetBrains.Annotations;
using UnityEngine;

public class bootstrapper : MonoBehaviour
{

    public GameObject GameManagerPrefab;
    public GameObject LevelManagerPrefab;

    void Start()
    {
        
        //sets manager instances if not already set, and insures they are children of the game manager
        if(GameManager.instance.levelManager == null)
        {
            GameManager.instance.levelManager = FindAnyObjectByType<LevelManager>();
            
        }
        
    }

    
}
