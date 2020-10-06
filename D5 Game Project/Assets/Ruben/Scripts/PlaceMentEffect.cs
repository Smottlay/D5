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
}
