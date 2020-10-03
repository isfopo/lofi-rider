using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public AudioSource click;
    public Quantize quantize;
    // private int currentLoop = 0;

    void Awake()
    {
        Quantize quantize = GetComponentInParent<Quantize>();
        AudioSource click = GetComponent<AudioSource>();
    }

    [Button]
    void StartClick()
    {
        quantize.Play(click, "4n", true);
    }
}
