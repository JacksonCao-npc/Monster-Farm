using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D myRig;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRig.velocity = Vector2.up * jumpVel;
                
               
            }
        }
    }

