using UnityEngine;

public class RestartManager : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.GlobalSpeed = 0;
        gameManager.GameHasStarted = false;
    }
}
