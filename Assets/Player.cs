using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 move;
    public float speed = 4;
    public Rigidbody rb;
    public int HP = 100;
    public int MP = 30;
    public animationcontroller controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.instance.uIManger.UpdateUI(HP, MP);
    }
    public void Move(InputAction.CallbackContext context)
    {
        if(GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            move = context.ReadValue<Vector2>();
            controller.Move(context);
            Debug.Log("getting movement");
        }
        
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            Debug.Log("dashing");
            controller.OnDash(context);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            Vector3 move3d = new Vector3(move.x, 0, move.y);

            rb.MovePosition(rb.position+ move3d * speed * Time.deltaTime);
        }
    }
    public void Pause()
    {
        move = Vector3.zero;
        GameManager.instance.gameStateManager.OnPause();
    }
    public void updateUI()
    {
        GameManager.instance.uIManger.UpdateUI(HP, MP);
    }
    public void heal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HP += 10;
            updateUI();
        }

    }
    public void takeDamage(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            HP -= 10;
            updateUI();
        }

    }
    public void RegenMana(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MP += 5;
            updateUI();
        }

    }
    public void CastSpell(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MP -= 5;
            updateUI();
        }

    }
}
