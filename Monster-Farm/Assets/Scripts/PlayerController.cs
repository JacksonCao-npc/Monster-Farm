using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    private Rigidbody2D myRig;
    private Animator myAnima;
    private BoxCollider2D myFeet;
    public bool isGround;
    public bool canDoubleJump;
    public float doubleJumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        myAnima = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationSwitch();
        Flip();
        
        CheckGrounded();
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
   
    void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 playerVel = new Vector2(horizontal * runSpeed, myRig.velocity.y);
        myRig.velocity = playerVel;

        bool playerHasXAxisSpeed = Mathf.Abs(myRig.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            myAnima.SetBool("run", true);
        }
        else
        {
            myAnima.SetBool("run", false);
        }
    }

    void Flip()
    {
        if(myRig.velocity.x>0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if(myRig.velocity.x<0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(0);
            if (isGround)
            {
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRig.velocity = Vector2.up * jumpVel;
                myAnima.SetBool("jump", true);
                canDoubleJump = true;
            }
        }
        
        
    }

    void AnimationSwitch()
    {
        myAnima.SetBool("idle", false);
        if(myRig.velocity.y<0.0f)
        {
            myAnima.SetBool("jump", false);
            myAnima.SetBool("fall", true);
            
        }
        else if(isGround)
        {
            myAnima.SetBool("fall", false);
            myAnima.SetBool("idle", true);
        }
       
        }
    }

   

