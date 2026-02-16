using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    public float jumpForce;
    public Transform visual;

    bool facingRight;

    bool isJumping;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float groundCheckRadius = 0.01f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }


    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); //right 1, left -1
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.15f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (isGrounded && isJumping)
        {
            isJumping = false;
        }

        Debug.Log("Grounded: " + isGrounded);
        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Space pressed");

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = visual.localScale;
        scaler.x *= -1f;
        visual.localScale = scaler;
    }
}
