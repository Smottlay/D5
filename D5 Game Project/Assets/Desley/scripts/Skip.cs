using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public bool skipping = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !skipping)
        {          
            Time.timeScale = 2;
            skipping = true;
        }
        else if (Input.GetButtonDown("Fire2") && skipping)
        {
            Time.timeScale = 1;
            skipping = false;
        }
    }
}
