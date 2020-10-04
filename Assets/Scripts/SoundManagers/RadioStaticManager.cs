using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStaticManager : MonoBehaviour
{
    public AudioSource RadioStatic;

    void Start()
    {
        RadioStatic = GetComponent<AudioSource>();

        RadioStatic.time = Random.Range(0, RadioStatic.clip.length);
        RadioStatic.Play();
    }
}
