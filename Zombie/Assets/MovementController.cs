using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    bool facingRight = true;
    private Rigidbody2D rigidBody;
    Animator anim;

    public Transform groundCheck;
    float groundRadius = 0.9f;
    public LayerMask whatIsGround;

    public float jumpForce = 600f;
    bool isGrounded = false;

    bool doubleJump = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("jump", !isGrounded);


        //if (isGrounded)
        //    doubleJump = false;
        //if (!isGrounded) return;

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));

        this.rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if (move < 0 && facingRight)
        {
            FlipFacing();
        }
    }

    private void Update()
    {
        //if ((isGrounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        //{
        //    anim.SetBool("jump", true);
        //    this.rigidBody.AddForce(new Vector2(0, jumpForce));

        //    if (!doubleJump && !isGrounded)
        //        doubleJump = true;
        //}
    }

    void FlipFacing()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
