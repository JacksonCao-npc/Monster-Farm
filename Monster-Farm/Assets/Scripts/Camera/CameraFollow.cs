using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;


    public float smoothing;

    public Vector2 minPostion;
    public Vector2 maxPostion;
    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    } 


    private void FixedUpdate()
    {
        if(player!= null)
        {
            if(transform.position != player.transform.position)
            {
                Vector3 playerPos = player.transform.position;
                playerPos.x = Mathf.Clamp(playerPos.x, minPostion.x, maxPostion.x);
               playerPos.y = Mathf.Clamp(playerPos.y, minPostion.y, maxPostion.y);
                transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
            }
        }
    }

    public void SetCamPostion(Vector2 minPos, Vector2 maxPos)
    {
        minPostion = minPos;
        maxPostion = maxPos;
    }


}
