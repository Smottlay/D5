using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFlicker : MonoBehaviour
{
    public float flashTime;
    public float flashDuration;
    public float holdTime;
    public float holdReset;
    public Image signalDark;
    //public bool toggleFlash;

    public void Start()
    {
        signalDark.enabled = true;
    }
    public void Update()
    {
         flashTime += flashDuration;
         if (flashTime >= 5f)
         {
            signalDark.enabled = false;
            holdTime -= Time.deltaTime;
            if (holdTime <= 0f)
            {
                flashTime = 0f;
                holdTime = holdReset;
            }
            
         }
        else
        {
            signalDark.enabled = true;
        }
        
    }
}
