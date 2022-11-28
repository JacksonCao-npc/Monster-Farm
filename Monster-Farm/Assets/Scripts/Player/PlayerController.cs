using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Varibles
    [Header("Set In Spector")]
    public float runSpeed;
    public int maxJump;
    public float jumpSpeed;
    public float dashSpeed;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public GameObject attackHitBox;
    public float attackDuration;
    public float restoreLayerTime;
    public float climbSpeed;
    
    #endregion

    #region Privaten Varibles
    [Header("Set Dynamically")]
    
    public int jumpRestTimes;
    public bool isGround;
    public float moveDir;
    public bool isOneWayPlatform;
    public bool isLadder;
    private bool isClimbing;
    private bool isJumping;
    private bool isFalling;
    private float playerGravity;
  
    #endregion

    #region Component Varibles
    private BoxCollider2D myFeet;
    public Rigidbody2D myRidgeBody;
    private Animator myAnima;
    
    public float myGravity = 2;
    #endregion
    void Start()
    {
        
        myRidgeBody = GetComponent<Rigidbody2D>();
        myAnima = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRidgeBody.gravityScale;
       
    }
    void Update()
    {
        if (GameController.playerIsAlive==true)
        {
            Jump();
            CheckAirStatus();
            Climb();
            Flip();
            CheckGround();
            CheckLadder();
            AnimationSwitch();
            OneWayPlatformCheck();
            BetterFalling();
           
        }
       


        if (GameController.playerIsAlive==false)
        {
            myRidgeBody.velocity = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        if (GameController.playerIsAlive==true)
        {
            Run();
        }

    }
    void Run()
    {
        if (GameController.canMove)
        {
            moveDir = Input.GetAxis("Horizontal");

            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRidgeBody.velocity.y);
            myRidgeBody.velocity = playerVel;

            bool playerHasXAxisSpeed = Mathf.Abs(myRidgeBody.velocity.x) > Mathf.Epsilon;
            if (playerHasXAxisSpeed)
            {
                myAnima.SetBool("Run", true);
            }
            else
            {
                myAnima.SetBool("Run", false);
            }
        }
    }
    void Flip()
    {
        if (myRidgeBody.velocity.x > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (myRidgeBody.velocity.x < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& jumpRestTimes>0)
        {
            myRidgeBody.velocity = new Vector2(myRidgeBody.velocity.x, 0);
            myRidgeBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            
            jumpRestTimes--;

            myAnima.SetBool("Jump", true);
        }

        if(isGround)
        {
            jumpRestTimes = maxJump;
        }
    }

    void Climb()
    {
        if(isLadder)
        {
            float moveY = Input.GetAxis("Vertical");
            if(moveY >0.5f || moveY<-0.5f)
            {
                myAnima.SetBool("Climb", true);
                myRidgeBody.gravityScale = 0.0f;
                myRidgeBody.velocity = new Vector2(myRidgeBody.velocity.x, moveY * climbSpeed);
            }
            else
            {
                if(isJumping || isFalling)
                {
                    myAnima.SetBool("Climb", false);
                }
                else
                {
                    myAnima.SetBool("Climb", false);
                    myRidgeBody.velocity = new Vector2(myRidgeBody.velocity.x, 0.0f);
                }
            }
        }

        else
        {
            myAnima.SetBool("Climb", false);
            myRidgeBody.gravityScale = playerGravity;
        }
    }
    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        isOneWayPlatform= myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }

    void CheckLadder()
    {
        isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    void AnimationSwitch()

    {
        bool upVelocity = Mathf.Abs(myRidgeBody.velocity.y) > 0;

        myAnima.SetBool("Idle", false);
        if (myAnima.GetBool("Jump"))
        {
            if (myRidgeBody.velocity.y < 0.0f)
            {
                myAnima.SetBool("Jump", false);
                myAnima.SetBool("Fall", true);
            }
        }
        else if(isGround)
        {
            myAnima.SetBool("Fall", false);
            myAnima.SetBool("Idle", true);
        }
    }
  
    void BetterFalling()
    {
        if(myRidgeBody.velocity.y<0)
        {
            myRidgeBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if(myRidgeBody.velocity.y<0&& !Input.GetButton("Jump"))
        {
            myRidgeBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    IEnumerator AttackHitBox(float attackDuration)
    {
        while(true)
        {
            yield return new WaitForSeconds(attackDuration);
            attackHitBox.SetActive(false);
            StopCoroutine(AttackHitBox(attackDuration));

        }
    }

    void OneWayPlatformCheck()
    {
        if(isGround&& gameObject.layer!= LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        float moveY = Input.GetAxis("Vertical");
        if(isOneWayPlatform && moveY < -0.1f )
        {
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke("RestorePlayerLayer", restoreLayerTime);
        }
    }

    void RestorePlayerLayer()
    {
        if(!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

    void CheckAirStatus()
    {
        isJumping = myAnima.GetBool("Jump") ;
        isFalling = myAnima.GetBool("Fall");
        isClimbing = myAnima.GetBool("Climb");

    }

    

}

    

   

   

