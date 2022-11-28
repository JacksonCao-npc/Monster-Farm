using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    

    private int movePosIndex;
    private Transform playerDefTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        movePosIndex = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,movePos[movePosIndex].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePos[movePosIndex].position) <0.1f)
                {
            if(waitTime<0)
            {
                if(movePosIndex == 0)
                {
                    movePosIndex = 1;
                }
                else
                {
                    movePosIndex = 0;
                }

                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            collision.gameObject.transform.parent = playerDefTransform;
        }
    }
}
