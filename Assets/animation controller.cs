using UnityEngine;
using UnityEngine.InputSystem;

public class animationcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    Vector2 move;
    public void Move(InputAction.CallbackContext context)
    {
        if (GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            move = context.ReadValue<Vector2>();
            Debug.Log("getting movement");
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            

            
        }
    }
    public void Pause()
    {
        move = Vector3.zero;
        GameManager.instance.gameStateManager.OnPause();
    }
}
