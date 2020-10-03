using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GUIStyle ScoreDisplayStyle;
    public GUIStyle GameOverStyle;
    public GUIStyle ButtonStyle;

    public Texture image1;

    public AudioSource RadioStaic;
    public GameManager gameManager;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Obstacle")
        {
            gameManager.Score--;
        }
    }

    //private void OnGUI()
    //{
    //    if (over)
    //    {
    //        GUI.Label(
    //            new Rect(
    //                Screen.width * 0.30f,
    //                Screen.height * 0.35f,
    //                Screen.width * 0.75f,
    //                Screen.height * 0.25f),
    //            "Game Over",
    //            GameOverStyle);

    //        if (GUI.Button(
    //            new Rect(
    //                Screen.width * 0.48f,
    //                Screen.height * 0.60f,
    //                50,
    //                50),
    //            image1,
    //            ButtonStyle) || Input.GetButton("Jump"))
    //        {
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //            Time.timeScale = 1;
    //        }
    //    }
    //}
}
