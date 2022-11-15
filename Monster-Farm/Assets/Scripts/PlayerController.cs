using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;

    private Rigidbody2D myRig;
    private Animator myAnima;
    public float jumpSpeed;
    public int maxJump;
    public int jumpRestTimes;
    public bool isGround;
    private BoxCollider2D myFeet;
    public float dashSpeed;
    private float moveDir;


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

        Flip();
        Jump();
        CheckGround();
        AnimationSwitch();
        Dash();

    }

    private void FixedUpdate()
    {
        Run();
        
    }


    void Run()
    {
       moveDir = Input.GetAxis("Horizontal");

        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRig.velocity.y);
        myRig.velocity = playerVel;

        bool playerHasXAxisSpeed = Mathf.Abs(myRig.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
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
        if (myRig.velocity.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (myRig.velocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& jumpRestTimes>0)
        {
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            myRig.velocity = Vector2.up * jumpVel;
            
            jumpRestTimes--;
        }

        if(isGround)
        {
            jumpRestTimes = maxJump;
        }
    }
    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    void AnimationSwitch()
    {
        myAnima.SetBool("idle", false);
        if(myRig.velocity.y<0.0f)
        {
            myAnima.SetBool("jump", false);
            myAnima.SetBool("fall", true);
        }
        else if(myRig.velocity.y>0.0f)
        {
            myAnima.SetBool("jump", true);
            myAnima.SetBool("fall", false);
        }
        if(isGround)
        {
            myAnima.SetBool("fall", false);
            myAnima.SetBool("idle", true);
        }
    }
    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            myRig.AddForce(Vector2.right * moveDir * dashSpeed);
            myAnima.SetTrigger("dash");
        }
    }
}

    

   

   

