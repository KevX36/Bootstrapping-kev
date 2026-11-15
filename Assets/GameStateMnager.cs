using Unity.VisualScripting;
using UnityEngine;

public class GameStateMnager : MonoBehaviour
{

    public void SetUp()
    {
        if (currentState == GameState.MainMenu)
        {
            OnStateChange();
        }
        else
        {
            SetState(GameState.MainMenu);
        }
    }
    public enum GameState
    {
        
        MainMenu,
        Paused,
        GamePlay




    }
    
    public GameState currentState { get; private set; }
    public GameState lastState { get; private set; } 
    
    

    public void SetState(GameState state)
    {
        if (currentState == state) return;
        lastState = currentState;
        currentState = state;
        OnStateChange();


    }
    
    private void OnStateChange()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                GameManager.instance.levelManager.LoadLevel("main menu");
                GameManager.instance.uIManger.HideAllUI(); 



                break;


            case GameState.GamePlay:
                GameManager.instance.uIManger.returnToGame();




                break;



            case GameState.Paused:
                
                GameManager.instance.uIManger.ShowPauseScreen();



                break;




            



        }
    }

    // Update is called once per frame
    
    public void OnPause()
    {
        if (currentState == GameState.GamePlay)
        {
            SetState(GameState.Paused);
        }
        else if (currentState == GameState.Paused)
        {
            
            SetState(GameState.GamePlay);
        }
        
    }
    
    public void ReturnToMainMenu()
    {
        SetState(GameState.MainMenu);
    }
    public void StartGame()
    {
        SetState(GameState.GamePlay);
        GameManager.instance.levelManager.LoadLevel("Gameplay");
    }
}
