using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Setting")]
    public int health;
    public int damage;
    public PlayerHealth playerHealth;
    public float flashTime;
    public GameObject bloodEffect;
    public GameObject dropCoin;

    private Color originalColor;
    private SpriteRenderer sr;
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
       
    }


    public void Update()
    {
       if(health<=0)
        {
            Destroy(gameObject);
            Instantiate(dropCoin, transform.position, Quaternion.identity);
        }
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

  void ResetColor()
    {
        sr.color = originalColor; 
    }

    public void TakenDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.camShake.Shake();
        FlashColor(flashTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player")&& collision.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            if(GameController.playerIsAlive ==true)
            {
                
                playerHealth.DamagePlayer(damage);
                Debug.Log(1);
            }
        }
    }





}
