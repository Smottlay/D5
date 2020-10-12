using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public bool skipping;
    public float skipSpeed;
    public float normalSpeed;

    public bool gameStarted;

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            if (Input.GetButtonDown("Jump") && !skipping && Time.timeScale >= 1)
            {
                Time.timeScale = skipSpeed;
                skipping = true;
            }
            else if (Input.GetButtonDown("Jump") && skipping && Time.timeScale >= 1)
            {
                Time.timeScale = normalSpeed;
                skipping = false;
            }
        }
    }
}
