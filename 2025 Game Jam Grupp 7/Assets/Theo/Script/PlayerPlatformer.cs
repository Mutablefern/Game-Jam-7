using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlatformer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movmentSpeed = 5f;
    [SerializeField] float jumpStrength = 7f;
    [SerializeField] float coyoteTime = 0.5f;

    [Header("Ground Check")]
    [SerializeField] Transform feetTransform;
    [SerializeField] Vector2 groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Gravity")]
    [SerializeField] float extraGarvity = 700f;
    [SerializeField] float gravityDelay = 0.2f;
    [SerializeField] float maxFallSpeedVelocity = -20f;

    Vector2 movementVector;
    float timeInAir, coyoteTimer;

    Rigidbody2D PlayerRigidbody;


    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CoyoteTimer();
        GravityDelay();
    }

    private void FixedUpdate()
    {
        Move();
        ExtraGravity();
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }

    void Move()
    {
        if ( movementVector.x < 0)
        {
            movementVector.x = -1;
        } else if ( movementVector.x > 0)
        {
            movementVector.x = 1;
        }
        PlayerRigidbody.linearVelocityX = movementVector.x * movmentSpeed; 
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (CheckGrounded())
            {
                ApplyJumpForce();
            }
            else if (coyoteTimer > 0f)
            {
                ApplyJumpForce();
            }
        }
    }

    void ApplyJumpForce()
    {
        PlayerRigidbody.linearVelocity = Vector2.zero;
        timeInAir = 0f;
        PlayerRigidbody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    void GravityDelay()
    {
        if (!CheckGrounded())
        {
            timeInAir += Time.deltaTime;
        }
        else
        {
            timeInAir = 0f;
        }
    }

    void CoyoteTimer()
    {
        if (CheckGrounded())
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
    }

    void ExtraGravity()
    {
        if (timeInAir > gravityDelay)
        {
            PlayerRigidbody.AddForce(new Vector2(0f, -extraGarvity * Time.deltaTime));

            if (PlayerRigidbody.linearVelocityY < maxFallSpeedVelocity)
            {
                PlayerRigidbody.linearVelocityY = maxFallSpeedVelocity;
            }
        }
    }

    public bool CheckGrounded()
    {
        Collider2D isGrounded = Physics2D.OverlapBox(feetTransform.position, groundCheck, 0f, groundLayer);
        return isGrounded;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(feetTransform.position, groundCheck);
    }
}
