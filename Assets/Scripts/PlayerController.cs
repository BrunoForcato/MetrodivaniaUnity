using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public float speed = 4;
    public float jumpForce = 200;
    public LayerMask whatIsGround;

    [HideInInspector]
    public bool lookingRight = true;

    private Rigidbody2D rb2d;
    public bool isGrounded = false;
    private bool jump = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputCheck();
        move();
    }

    void inputCheck()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
    }

    void move()
    {
        float horizontalForceButton = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalForceButton * speed, rb2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, whatIsGround);

        if ((horizontalForceButton > 0 && !lookingRight) || (horizontalForceButton < 0 && lookingRight))
         Flip();

        if (jump)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }
} 