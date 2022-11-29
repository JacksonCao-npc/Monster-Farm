using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogbox;
    public Text dialogText;
    public string signText;
    private bool isPlayerInSign;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& isPlayerInSign)
        {
            dialogText.text = signText;
            dialogbox.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = false;
            dialogbox.SetActive(false);
        }
    }
}
