using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerController.IMovementActions
{
    private PlayerController inputActions;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;

    private Vector2 moveInput;

    private void Awake()
    {
        inputActions = new PlayerController();
        inputActions.Movement.SetCallbacks(this);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.Enable();
        }
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.Disable();
        }
    }

    private void FixedUpdate()
    {
        float speed = IsRunning() ? runSpeed : walkSpeed;
        rb.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }

    private void Update()
    {
        UpdateAnimation();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Flip sprite berdasarkan arah horizontal
        if (moveInput.x != 0)
            sprite.flipX = moveInput.x < 0;
    }

    private void UpdateAnimation()
    {
        if (moveInput == Vector2.zero)
        {
            animator.SetInteger("state", 0); // Idle
        }
        else if (IsRunning())
        {
            animator.SetInteger("state", 2); // Run
        }
        else
        {
            animator.SetInteger("state", 1); // Walk
        }
    }

    private bool IsRunning()
    {
        return Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed;
    }
}
