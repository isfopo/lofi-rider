﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;

    public bool GameHasStarted;

    public Animator transition;
    public float transisitionTime = 1;

    public AudioMixerSnapshot In;
    public AudioMixerSnapshot Out;

    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) + StartSpeed;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CallNextScene();
        }
    }

    public void CallNextScene()
    {
        GameHasStarted = true;
        StartCoroutine(
            LoadScene(
                Random.Range(1, SceneManager.sceneCountInBuildSettings - 1))
            );
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("StartFade");
        Out.TransitionTo(.5f);

        yield return new WaitForSeconds(transisitionTime);

        SceneManager.LoadScene(levelIndex);
        transition.SetTrigger("EndFade");
        In.TransitionTo(.5f);
    }
}
