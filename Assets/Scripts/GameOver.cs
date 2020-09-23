using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool over;

    public GUIStyle ScoreDisplayStyle;
    public GUIStyle GameOverStyle;
    public GUIStyle ButtonStyle;

    public Texture image1;

    public AudioSource RadioStaic;

    //public int score;
    //private float scoreIncrimate;

    private void Start()
    {
        over = false;
    }

    //void Update()
    //{
    //    scoreIncrimate += Time.deltaTime * 10;
    //    score = (int)scoreIncrimate;

    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Obstacle")
        {
            Time.timeScale = 0;
            RadioStaic.Play();
            over = true;
        }
    }

    private void OnGUI()
    {
        // string scoreDisplay = score.ToString();

        // GUI.Label(new Rect(Screen.width * 0.7f, Screen.height * 0.07f, Screen.width * 0.2f, Screen.height * 0.05f), "Score: " + scoreDisplay, ScoreDisplayStyle);

        if (over)
        {
            GUI.Label(
                new Rect(
                    Screen.width * 0.30f,
                    Screen.height * 0.35f,
                    Screen.width * 0.75f,
                    Screen.height * 0.25f),
                "Game Over",
                GameOverStyle);

            if (GUI.Button(
                new Rect(
                    Screen.width * 0.48f,
                    Screen.height * 0.60f,
                    50,
                    50),
                image1,
                ButtonStyle) || Input.GetButton("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
        }
    }
}
