using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;
    public string[] SceneNames;

    public bool GameHasStarted;

    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) + StartSpeed;
        }
    }

    public void CallNextScene()
    {
        GameHasStarted = true;
        SceneManager.LoadScene(
            SceneNames[Random.Range(0,SceneNames.Length - 1)]);
    }
}
