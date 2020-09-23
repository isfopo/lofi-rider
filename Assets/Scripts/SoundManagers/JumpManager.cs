using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    public AudioSource[] sources;

    void Start()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 && GameObject.FindGameObjectWithTag("Player").transform.position.y < 0.1)
        {
            sources[Random.Range(0, sources.Length)].Play();
        }
    }
}
