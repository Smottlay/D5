﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticle : MonoBehaviour
{
    public ParticleSystem splash;
    private float timer = 3;

    void Start()
    {
        splash.Play();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
