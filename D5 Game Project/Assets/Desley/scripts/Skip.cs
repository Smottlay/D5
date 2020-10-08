using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public bool skipping;
    public float skipSpeed;
    public float normalSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !skipping && Time.timeScale >= 1)
        {
            Time.timeScale = skipSpeed;
            skipping = true;
        }
        else if (Input.GetButtonDown("Fire2") && skipping && Time.timeScale >= 1)
        {
            Time.timeScale = normalSpeed;
            skipping = false;
        }
    }
}
