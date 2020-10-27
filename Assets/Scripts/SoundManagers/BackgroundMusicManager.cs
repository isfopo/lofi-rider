using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [InfoBox("Add audio sources for each loop", EInfoBoxType.Normal)]
    public AudioSource[] BackgroundMusic;
    [InfoBox("Add at which score the next loop starts", EInfoBoxType.Normal)]
    public int[] ScoreForNext;
    public string[] Beatcodes;

    private Quantize quantize;
    private GameManager gameManager;

    private int currentLoop = 0;

    void Awake()
    {
        quantize = GetComponentInParent<Quantize>();
        BackgroundMusic = GetComponents<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();

        quantize.Play(BackgroundMusic[currentLoop], Beatcodes[currentLoop], true);
    }

    private void Update()
    {
        if (gameManager.Score >= ScoreForNext[currentLoop])
        {
            PlayNext();
        }
    }

    void PlayNext()
    {
        try
        {
            quantize.Stop(BackgroundMusic[currentLoop], Beatcodes[currentLoop +1]);
            currentLoop++;

            if (currentLoop == BackgroundMusic.Length)
            {
                quantize.QuantizeCall(() => gameManager.CallNextScene(), Beatcodes[currentLoop - 1]);
            }

            quantize.Play(BackgroundMusic[currentLoop], Beatcodes[currentLoop], true);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("Ready for next scene");
        }
    }
}
