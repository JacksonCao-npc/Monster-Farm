using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private Renderer myRenderer;
    public int Blinks;
    public float blinkTime;
  
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
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
            Destroy(gameObject);
            
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
