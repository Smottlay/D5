using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySystem : MonoBehaviour
{
    public ParticleSystem[] particleSystemies;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ActivateAllParticles();
        }

        void ActivateAllParticles()
        {
            particleSystemies[0].Play();
            
        }
    }
}
