using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private SpriteRenderer sr;
    public float flashTime;
    private Color originalColor;
    public GameObject bloodEffect;
    [SerializeField] PlayerHealth playerHealth;
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    public void Update()
    {
       if(health<=0)
        {
            Destroy(gameObject);
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
            if(PlayerController.isAlive ==true)
            {
                
                playerHealth.DamagePlayer(damage);
                Debug.Log(1);
            }
        }
    }





}
