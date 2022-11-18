using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public float flashTime;

    
    
    // Start is called before the first frame update
   public void Start()
    {
       
    }

    // Update is called once per frame
    public void Update()
    {
       if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakenDamage(int damage)
    {
        health -= damage;
        
        
    }


   
    

}
