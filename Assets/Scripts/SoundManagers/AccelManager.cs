using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelManager : MonoBehaviour
{
    public AudioSource Source;

    public float pitchIncrement;

    public float pitchMin;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ( Input.GetAxis("Horizontal") > 0 )
        {
            Source.pitch += pitchIncrement;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Source.pitch -= pitchIncrement;
        }
        else
        {
            if (Source.pitch < 1 )
            {
                Source.pitch += pitchIncrement;
            }
            else if ( Source.pitch > 1 )
            {
                Source.pitch -= pitchIncrement;
            }
        }

        Source.pitch = Source.pitch < pitchMin ? pitchMin : Source.pitch;
    }
}
