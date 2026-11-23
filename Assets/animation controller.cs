using UnityEngine;
using UnityEngine.InputSystem;

public class animationcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    Vector2 move;
    //animation veriables
    [SerializeField] private Animator animator;
    private int MoveHashX = Animator.StringToHash("MoveX");
    private int MoveHashY = Animator.StringToHash("MoveY");
    private int isMovingHash = Animator.StringToHash("IsMoving");
    private int dashTriggerHash = Animator.StringToHash("Dashing");
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

            if (move != Vector2.zero)
            {
                animator.SetBool(isMovingHash, true);
                animator.SetFloat(MoveHashX, move.x);
                animator.SetFloat(MoveHashY, move.y);

            }
            else
            {
                animator.SetBool(isMovingHash, false);
            }

        }
    }
    public void Pause()
    {
        move = Vector3.zero;
        GameManager.instance.gameStateManager.OnPause();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && GameManager.instance.gameStateManager.currentState == GameStateMnager.GameState.GamePlay)
        {
            animator.SetTrigger(dashTriggerHash);
            Debug.Log("dashing");
        }
    }
}
