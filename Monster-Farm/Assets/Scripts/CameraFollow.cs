using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float playerPos;
    public Vector3 cameraOffSet = new Vector3(0, 0, -25);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position.x;
        this.transform.position = new Vector3(playerPos, 0, 0) + cameraOffSet;
    }
}
