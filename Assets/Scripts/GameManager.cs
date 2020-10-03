using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 1;
    public float GlobalSpeed;
    public float StartSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score = Score <= 0 ? 0 : Score;

        GlobalSpeed = Mathf.Log(Score, 2) + StartSpeed;

        
    }
}
