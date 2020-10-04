using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource[] BackgroundMusic;
    public int[] ScoreForNext;
    public Quantize quantize;
    public GameManager gameManager;

    private int currentLoop = 0;

    void Awake()
    {
        quantize = GetComponentInParent<Quantize>();
        BackgroundMusic = GetComponents<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();

        quantize.Play(BackgroundMusic[currentLoop], "8b", true);
    }

    private void Update()
    {
        if (gameManager.Score >= ScoreForNext[currentLoop])
        {
            PlayNext();
        }
    }

    [Button]
    void PlayNext()
    {
        quantize.Stop(BackgroundMusic[currentLoop], "8b");
        currentLoop++;

        if (currentLoop == BackgroundMusic.Length - 1)
        {
            // end of song, call next scene
        }

        quantize.Play(BackgroundMusic[currentLoop], "8b", true);
    }
}
