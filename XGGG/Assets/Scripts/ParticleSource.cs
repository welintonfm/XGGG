using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSource : MonoBehaviour
{
    public ParticleSystem particle;

    public void PlayMode(){
        particle.Play();
    }
    
}
