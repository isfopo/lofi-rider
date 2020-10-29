using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    public ParticleSystem CollectParticle;
    public AudioSource CollectSound;

    public void CreateEffect()
    {
        CollectParticle.Play();
        CollectSound.Play();

        Destroy(gameObject, CollectParticle.main.duration);
    }
}
