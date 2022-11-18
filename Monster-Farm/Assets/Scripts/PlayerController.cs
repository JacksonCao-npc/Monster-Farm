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
    #endregion

    #region Privaten Varibles
    [Header("Set Dynamically")]
    
    public int jumpRestTimes;
    public bool isGround;
    public float moveDir;
    #endregion

    #region Component Varibles
    private BoxCollider2D myFeet;
    private Rigidbody2D myRig;
    private Animator myAnima;
    #endregion
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        myAnima = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Flip();
        Jump();
        CheckGround();
        AnimationSwitch();
        Dash();
        BetterFalling();
        
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
            myRig.velocity = new Vector2(myRig.velocity.x, 0);
            myRig.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            
            jumpRestTimes--;

            myAnima.SetBool("jump", true);
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
        bool upVelocity = Mathf.Abs(myRig.velocity.y) > 0;
        myAnima.SetBool("idle", false);
        if(myRig.velocity.y<0.0f)
        {
            myAnima.SetBool("jump", false);
            myAnima.SetBool("fall", true);
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
    void BetterFalling()
    {
        if(myRig.velocity.y<0)
        {
            myRig.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if(myRig.velocity.y<0&& !Input.GetButton("Jump"))
        {
            myRig.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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
}

    

   

   

