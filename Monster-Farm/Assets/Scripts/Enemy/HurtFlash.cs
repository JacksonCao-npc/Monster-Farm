using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtFlash : MonoBehaviour
{
    

    public float flashTime;

    public SpriteRenderer sr;
    private Color originalColor;



    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }
}
