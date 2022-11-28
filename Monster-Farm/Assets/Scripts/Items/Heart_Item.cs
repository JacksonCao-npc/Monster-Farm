using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Item : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player")&& collision.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            Destroy(gameObject);
            playerHealth.HealPlayer(1);
        }
    }
}
