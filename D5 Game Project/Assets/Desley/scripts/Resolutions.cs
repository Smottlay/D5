using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Resolutions : MonoBehaviour
{
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
