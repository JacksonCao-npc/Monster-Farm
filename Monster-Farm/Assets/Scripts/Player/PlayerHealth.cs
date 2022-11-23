using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private Renderer myRenderer;
    public int Blinks;
    public float blinkTime;
    private Animator anima;
    public float dieTime;

 
  
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        anima = GetComponent<Animator>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void DamagePlayer(int damage)
    {
        health -= damage;
        
        if (health <=0)
        {
            anima.SetTrigger("Die");
            PlayerController.isAlive = false;


        }
        BlinkPlayer(Blinks, blinkTime);
    }

    
    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    
    IEnumerator  DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i <numBlinks *2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }
}
