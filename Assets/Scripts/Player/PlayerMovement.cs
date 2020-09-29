using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float moveForce;

    [SerializeField]
    private float maxMoveSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int maxAirJumps;
    #endregion

    #region Cached Components
    private Rigidbody2D rb;
    #endregion


    #region Private Variables
    private float movementX;
    private float airJumps;

    private bool isGrounded = false;

    private bool facingRight = true;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool FacingRight { get => facingRight; set => facingRight = value; }
    #endregion

    #region On Start Functions
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetAirJumps();
    }
    #endregion

    #region Update Functions
    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && airJumps >= 1) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region Movement Functions
    private void Move()
    {
        if (movementX * rb.velocity.x <= 0) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        rb.AddForce(new Vector2(moveForce * movementX, 0));

        if (rb.velocity.x > maxMoveSpeed) {
            rb.velocity = new Vector2(maxMoveSpeed, rb.velocity.y);
        } else if (rb.velocity.x < -maxMoveSpeed) {
            rb.velocity = new Vector2(-maxMoveSpeed, rb.velocity.y);
        }

        if ((movementX > 0 && !FacingRight) || (movementX < 0 && FacingRight))
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Jump()
    {
        airJumps--;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    #endregion

    #region Public functions
    public void ResetAirJumps()
    {
        airJumps = maxAirJumps;
    }
    #endregion



}
