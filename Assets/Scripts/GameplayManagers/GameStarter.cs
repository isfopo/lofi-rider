using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gameManager.GameHasStarted = true;
            SceneManager.LoadScene("TestScene");
        }
    }
}
