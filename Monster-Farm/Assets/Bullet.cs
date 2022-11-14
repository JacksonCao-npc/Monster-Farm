using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collideWith = collision.gameObject;
        if(collideWith.tag =="Enemy")
        {
            Destroy(collideWith);
            Destroy(gameObject);
        }

      

    }
}
