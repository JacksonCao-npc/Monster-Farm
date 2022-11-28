using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    [Header("DeathBringerOnly")]
    public Animator anima;
    public float speed;
    public float startWaitTime;
    public float waitTime;

    public GameObject wizard;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    [SerializeField] bool lockTarget;
    [SerializeField] Transform playerPos;

    // Start is called before the first frame update
    new public void Start()
    {
        anima = GetComponent<Animator>();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();

    }

    new protected void Update()
    {
        Attack();
    }
    

    // Update is called once per frame
    public void FixedUpdate()
    {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
            anima.SetBool("Walk", true);
        if (lockTarget == false)
        {
            if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
            {

                if (waitTime <= 0)
                {
                    movePos.position = GetRandomPos();
                    waitTime = startWaitTime;
                    anima.SetBool("Walk", true);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if(lockTarget == true)
        {
            movePos = playerPos;
        }

            if (Vector2.Distance(transform.position, movePos.position) < 1f)
            {
                anima.SetBool("Walk", false);
            }
        
        if (wizard.transform.position.x < movePos.transform.position.x)
        {
            wizard.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (wizard.transform.position.x > movePos.transform.position.x)
        {
            wizard.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }


    new private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            lockTarget = true;
            playerPos = collision.gameObject.transform;
            if (collision.gameObject.CompareTag("PlayerAttack") && health > 0)
            {
                anima.SetTrigger("damage");
            }
        }


    }

    Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            leftDownPos.position.y);

        return randomPos;
    }

    void Attack()
    {
        if(playerPos.position.x <0.5f)
        {
            anima.SetTrigger("Attack");
        }
    }

   
}

        


    
    

