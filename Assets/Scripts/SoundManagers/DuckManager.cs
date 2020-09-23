using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public AudioSource[] sources;
    private bool shouldPlay;
    private GameObject player;

    void Start()
    {
        sources = GetComponentsInChildren<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && player.transform.position.y > -0.095 && player.transform.position.y < 0.1)
        {
            sources[Random.Range(0, sources.Length)].Play();
        }
    }
}
