using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider _slider;
    public GameManager gameManager;
    public BackgroundMusicManager backgroundMusicManager;

    void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
        gameManager = FindObjectOfType<GameManager>();
        backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();

        _slider.maxValue = backgroundMusicManager.FinalScore;
    }

    void Update()
    {
        _slider.value = gameManager.Score;
    }
}
