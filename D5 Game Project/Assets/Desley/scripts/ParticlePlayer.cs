using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem particle;

       public void ParticleStart()
        {
        particle.Play();
        }   
}
