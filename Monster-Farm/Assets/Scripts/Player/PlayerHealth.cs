using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private Renderer myRenderer;
    public int blinks;
    public float blinkTime;
    private Animator anima;
    public float dieTime;
    public FlashScreen flashScreen;


    private PolygonCollider2D polygonCollider2D;
    public float hitBoxCDTime;

 
  
    // Start is called before the first frame update
    public void Start()
    {
        
        health = HealthBar.HealthMax = 10;
        health = HealthBar.HealthCurrent = 10;
        
        myRenderer = GetComponent<Renderer>();
        anima = GetComponent<Animator>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void DamagePlayer(int damage)
    {
        health -= damage;
        HealthBar.HealthCurrent= health;

        if(health <0)
        {
            health = 0;
        }
        if (health <=0)
            
        {
            anima.SetTrigger("Die");
            GameController.playerIsAlive = false;
            Invoke("KillPlayer", 3);
        }
        BlinkPlayer(blinks, blinkTime);
        flashScreen.ScreenFlash();
        polygonCollider2D.enabled = false;
        StartCoroutine(DisplayPlayerHitBox());
    }

    void KillPlayer()
    {
        Destroy(gameObject);
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

    IEnumerator DisplayPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCDTime);
        polygonCollider2D.enabled = true;
    }

}
