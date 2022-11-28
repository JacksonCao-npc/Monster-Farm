using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static CameraShake camShake;
    public static bool playerIsAlive;
    public static bool canMove;

    private void Awake()
    {
        canMove = true;
        playerIsAlive = true;
    }
}
