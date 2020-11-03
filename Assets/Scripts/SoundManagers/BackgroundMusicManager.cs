using NaughtyAttributes;
using UnityEngine;
using System;

public class BackgroundMusicManager : MonoBehaviour
{
    [InfoBox("Add audio sources for each loop", EInfoBoxType.Normal)]
    public AudioSource[] BackgroundMusic;
    [InfoBox("Add at which score the next loop starts", EInfoBoxType.Normal)]
    public int[] ScoreForNext;
    public int FinalScore;
    public string[] Beatcodes;

    private Quantize quantize;
    public GameManager gameManager;

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
        if ( gameManager.Score >= FinalScore )
        {
            gameManager.CallNextScene();
        }
        try
        {
            if (gameManager.Score >= ScoreForNext[currentLoop])
            {
                PlayNext();
            }
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("Last Loop");
        }
    }

    void PlayNext()
    {
        if (currentLoop < BackgroundMusic.Length)
        {
            quantize.Stop(BackgroundMusic[currentLoop], Beatcodes[currentLoop]);
            currentLoop++;
        }

        if (currentLoop < BackgroundMusic.Length)
        {
            quantize.Play(BackgroundMusic[currentLoop], Beatcodes[currentLoop], true);
        }
    }
}
