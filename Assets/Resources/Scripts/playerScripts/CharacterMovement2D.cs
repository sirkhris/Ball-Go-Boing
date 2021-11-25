using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); //Move takes 3 variables: our movement, a bool for crouch, a bool for jump
        jump = false;
    }
    //private Rigidbody2D rb;

    ////ground movement
    //private float movementH;
    //[SerializeField] float speed = 5;
    //private float runningMod = 2;
    //private bool facingRight = true;
    //private bool isRunning = false;

    ////jump movement
    //[SerializeField] Transform groundCheckCollider;
    //[SerializeField] LayerMask groundLayer;
    //[SerializeField] float jumpPower = 350;
    //const float groundCheckRadius = 0.2f;
    //private bool isGrounded = false;
    //private bool isJumping = false;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    movementH = Input.GetAxisRaw("Horizontal");
    //    if(Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        isRunning = true;
    //    }
    //    else if (Input.GetKeyUp(KeyCode.LeftShift))
    //    {
    //        isRunning = false;
    //    }

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        isJumping = true;
    //    }
    //    else if (Input.GetButtonUp("Jump"))
    //    {
    //        isJumping = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    GroundCheck();
    //    Move(movementH, isJumping);
    //}

    //void GroundCheck()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
    //    if (colliders.Length > 0)
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void Move(float dir, bool jumpFlag)
    //{
    //    #region Move & Run
    //    float xVal = dir * speed * 100 * Time.fixedDeltaTime;
    //    //if shift is down, multiply movement speed
    //    if (isRunning == true && isGrounded == true)
    //    {
    //        xVal *= runningMod;
    //    }

    //    Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
    //    rb.velocity = targetVelocity;

    //    Vector3 currentScale = transform.localScale;
    //    if (facingRight == true && dir < 0) //if going left and facing right, flip transform
    //    {
    //        currentScale.x = -1;
    //        facingRight = false;
    //    }
    //    else if (facingRight == false && dir > 0) //if going left and facing right, flip transform
    //    {
    //        currentScale.x = 1;
    //        facingRight = true;
    //    }
    //    currentScale = transform.localScale;
    //    #endregion

    //    if(isGrounded == true && jumpFlag )
    //    {
    //        rb.AddForce(new Vector2(0f, jumpPower));
    //        isGrounded = false;
    //        jumpFlag = false;
    //    }
    //}
}
