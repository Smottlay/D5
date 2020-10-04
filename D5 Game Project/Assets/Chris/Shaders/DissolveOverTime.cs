using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOverTime : MonoBehaviour
{
    public Material dissolveMaterial;

    void Start()
    {
        dissolveMaterial.SetFloat("_TimeSlider", Time.deltaTime);
    }
}
