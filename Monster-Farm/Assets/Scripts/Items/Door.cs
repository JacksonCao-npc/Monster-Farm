using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool doorTranslating;
    public Transform backDoor;
    private bool isDoor;
    private Transform playerTransform;
  

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        EnyerDoor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = true;
            Debug.Log("EnterDoor");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = false;
            Debug.Log("ExitDoor");
        }
    }

    void EnyerDoor()
    {
        if(isDoor && Input.GetKeyDown(KeyCode.E))
        {
            playerTransform.position = backDoor.position;
                       
        }
    }

}
