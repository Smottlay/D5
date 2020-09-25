using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 2;
        }
        if (Input.GetButtonUp("Jump"))
        {
            Time.timeScale = 1;
        }
    }
}
