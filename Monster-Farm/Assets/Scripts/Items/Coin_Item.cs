using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Item : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& collision.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            CoinUI.CurrentCoinQuantity += 1;
            Destroy(gameObject);
        }
    }
}
