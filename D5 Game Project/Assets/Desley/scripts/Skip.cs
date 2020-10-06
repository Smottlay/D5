using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public bool skipping = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !skipping)
        {
            skipping = true;
            Time.timeScale = 2;
        }
        if (Input.GetButton("Jump") && skipping)
        {
            skipping = false;
            Time.timeScale = 1;
        }
    }
}
