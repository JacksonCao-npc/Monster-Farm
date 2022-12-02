using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 cameraOffSet;
    public float pressDownCamera;
    
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
              
                Vector3 playerPos = player.position + cameraOffSet;
                transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
            }
        }
    }
}
