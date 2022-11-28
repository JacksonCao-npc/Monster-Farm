using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    public Image img;
    public float time;
    public int screenBlink;
    public float screenBlinkTimes;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScreenFlash()
    {
        StartCoroutine(DoBlinks(screenBlink,screenBlinkTimes));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
           img.enabled = !img.enabled;
            yield return new WaitForSeconds(seconds);
        }
        img.enabled = false;
    }
}
