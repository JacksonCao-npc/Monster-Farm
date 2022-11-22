using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator camAnima;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Shake()
    {
        camAnima.SetTrigger("Shake");
    }
}
