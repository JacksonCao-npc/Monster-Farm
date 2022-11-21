using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    public Animator anima;
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public GameObject wizard;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    

    // Start is called before the first frame update
    new public void Start()
    {
        anima = GetComponent<Animator>();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();

    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        anima.SetBool("walk", true);

        if(Vector2.Distance(transform.position,movePos.position)<0.1f)
        {
            
            if(waitTime<=0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
                anima.SetBool("walk", true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Vector2.Distance(transform.position, movePos.position) < 1f)
        {
            anima.SetBool("walk", false);
        }

        if(wizard.transform.position.x< movePos.transform.position.x)
        {
            wizard.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (wizard.transform.position.x > movePos.transform.position.x)
        {
            wizard.transform.localRotation = Quaternion.Euler(0,0, 0);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerAttack")&& health>0)
        {
            anima.SetTrigger("damage");


        }


    }

    Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));

        return randomPos;
    }
}
