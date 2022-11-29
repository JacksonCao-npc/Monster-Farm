using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    
    public int spikeDamage;
   
    public PlayerHealth playerHealth;

   


    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (GameController.playerIsAlive)
        {
            if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
            {
                playerHealth.DamagePlayer(spikeDamage);
            }
        }
    }
}
