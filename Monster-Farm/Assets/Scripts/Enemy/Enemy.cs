using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject bloodEffect;
    private PlayerHealth playerHealth;
    private PlayerController playerController;



    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


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
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.camShake.Shake();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player")&& collision.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth!=null)
            {
                
                playerHealth.DamagePlayer(damage);
                Debug.Log(1);
            }
        }
    }





}
