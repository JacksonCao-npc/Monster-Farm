using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    
    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    } 


    private void FixedUpdate()
    {
        if(player !=null)
        {
            if(transform.position!= player.position)
            {
                Vector3 playerPos = player.position;
                transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
            }
        }
    }
}
