using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float inputDirection;

    [Header("Movement Variables")]
    [SerializeField] float movementSpeed = 1;
    [SerializeField] float jumpForce = 1;

    [Header("Grounded")]
    [SerializeField] float isGroundedDistance = 0.6f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TakeInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void TakeInput()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            PlayerJump();
        }
    }

    private void MovePlayer()
    {
        rb.linearVelocity = new Vector2(inputDirection * movementSpeed, rb.linearVelocityY);
    }

    private void PlayerJump()
    {
        rb.linearVelocityY = 0;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, isGroundedDistance, groundLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
