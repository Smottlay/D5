using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMentEffect : MonoBehaviour
{
    public ParticleSystem placingEffect;

    private void Awake()
    {
        placingEffect.Play();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            placingEffect.Play();
        }
    }
}
