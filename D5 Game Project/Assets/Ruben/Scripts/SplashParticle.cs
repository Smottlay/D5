using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticle : MonoBehaviour
{
    public ParticleSystem splash;

    void Start()
    {
        splash.Play();
    }

    private void Update()
    {
        
    }
}
