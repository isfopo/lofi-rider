﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource BackgroundMusicSource;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
