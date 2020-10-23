using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    float xDisplacement = 0;
    public float sprintSpeedMultipler = 2;
    private float speedMultiplier = 1;
    public float speed = 5;
    public float dashSpeedMultipler = 5;
    private float dashTimer;
    public float dashTime;
    private float dashCurrentTime;
    public float dashCooldown = 2;
    public float jumpForce;
    private bool isGrounded;
    private bool isOnMovingPlatform = false;
    private float movingPlatformSpeedX;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Sprint();
        Jump();
        if (!isOnMovingPlatform)
        {
            Move();
        }
        if (isOnMovingPlatform)
        {
            MoveOnMovingPlatform();
        }
        
    }

    private void Move()
    {
        xDisplacement = Input.GetAxis("Horizontal") * speed * speedMultiplier;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }         
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = sprintSpeedMultipler;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMultiplier = 1;
        }
    }

    public void Dash()
    {
        dashTimer += Time.deltaTime;
        if ((Input.GetKey(KeyCode.V) && dashTimer > dashCooldown) || (Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.LeftShift) && dashTimer > dashCooldown))
        {
            dashCurrentTime = dashTime;
            dashTimer = 0;
        }

        if (dashCurrentTime > 0)
        {
            speedMultiplier = dashSpeedMultipler;
            dashCurrentTime--;
        }

        if(dashCurrentTime == 0)
        {
            speedMultiplier = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
           // MoveOnMovingPlatform(collision);
            isOnMovingPlatform = true;
            movingPlatformSpeedX = collision.gameObject.GetComponent<MovingPlatformScript>().speedX;     
        }   
    }

    private void MoveOnMovingPlatform()
    {
        xDisplacement = Input.GetAxis("Horizontal") * speed * speedMultiplier;
        rb.velocity = new Vector2(xDisplacement + movingPlatformSpeedX, rb.velocity.y);   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnMovingPlatform = false;
    }
}
