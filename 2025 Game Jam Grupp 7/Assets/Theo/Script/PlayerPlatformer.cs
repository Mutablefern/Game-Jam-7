using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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

    [Header("Grafik")]
    [SerializeField] float runAnimationSpeed;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;
    [SerializeField] Sprite sprite4;
    [SerializeField] Sprite sprite5;

    [Header("Misc")]
    [SerializeField] GameObject otherPlayer;

    Vector2 movementVector, startPos;
    float timeInAir, coyoteTimer, lastRunTime;
    bool isRunning, isJumping, hasWon, hasLost;


    Rigidbody2D PlayerRigidbody;
    SpriteRenderer spriteRenderer;
    PlayerPlatformer otherPlayerScript;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        otherPlayerScript = otherPlayer.GetComponent<PlayerPlatformer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        CoyoteTimer();
        GravityDelay();
        Animate();
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
        if (hasWon || hasLost) 
        { 
            PlayerRigidbody.linearVelocityX = 0;
            return;
        }
        if ( movementVector.x < 0)
        {
            movementVector.x = -1;
            isRunning = true;
            spriteRenderer.flipX = true;
        } 
        else if ( movementVector.x > 0)
        {
            movementVector.x = 1;
            isRunning = true;
            spriteRenderer.flipX = false;
        }
        else
        {
            isRunning = false;
        }
        PlayerRigidbody.linearVelocityX = movementVector.x * movmentSpeed; 
    }

    void OnButtonOne(InputValue value)
    {
        if (hasWon || hasLost) { return; }
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
        isJumping = true;
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

    void Animate()
    {
        if (hasWon)
        {
            spriteRenderer.sprite = sprite5;
        }
        else if (hasLost)
        {
            spriteRenderer.sprite = sprite4;
        }
        else if (isJumping)
        {
            if (CheckGrounded() && PlayerRigidbody.linearVelocityY == 0)
            {
                isJumping = false;
            }
            else
            {
                spriteRenderer.sprite = sprite3;
            }
        }
        else if (!isRunning)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (isRunning)
        {
            if (spriteRenderer.sprite == sprite1 && lastRunTime + runAnimationSpeed < Time.time)
            {
                spriteRenderer.sprite = sprite2;
                lastRunTime = Time.time;
            }
            else if (lastRunTime + runAnimationSpeed < Time.time)
            {
                spriteRenderer.sprite = sprite1;
                lastRunTime = Time.time;
            }
        }
    }

    public void Loss()
    {
        hasLost = true;
        boxCollider.enabled = false;
        PlayerRigidbody.linearVelocity = Vector2.zero;
        PlayerRigidbody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    public bool CheckGrounded()
    {
        Collider2D isGrounded = Physics2D.OverlapBox(feetTransform.position, groundCheck, 0f, groundLayer);
        return isGrounded;
    }

    public bool GetHasWon()
    {
        return hasWon;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !otherPlayerScript.GetHasWon())
        {
            Debug.Log(name + " wins");
            hasWon = true;
            otherPlayerScript.Loss();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(feetTransform.position, groundCheck);
    }
}
