using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;

    public bool GameHasStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) + StartSpeed;
        }
    }
}
