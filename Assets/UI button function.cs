using UnityEngine;

public class UIbuttonfunction : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.instance.gameStateManager.StartGame();
    }
    public void Quit()
    {
        GameManager.instance.levelManager.QuitGame();
    }
    public void BackToMenu()
    {
        GameManager.instance.gameStateManager.ReturnToMainMenu();
    }
    public void BackToGame()
    {
        GameManager.instance.gameStateManager.OnPause();
    }
}
