using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource[] BackgroundMusic;
    public Quantize quantize;
    private int currentLoop = 0;

    void Awake()
    {
        Quantize quantize = GetComponentInParent<Quantize>();
        AudioSource[] BackgroundMusic = GetComponents<AudioSource>();

        quantize.Play(BackgroundMusic[currentLoop], "8b", true);
    }

    [Button]
    void PlayNext()
    {
        quantize.Stop(BackgroundMusic[currentLoop], "8b");
        currentLoop++;

        if (currentLoop == BackgroundMusic.Length - 1)
        {
            currentLoop = 0;
        }

        quantize.Play(BackgroundMusic[currentLoop], "8b", true);
    }
}
