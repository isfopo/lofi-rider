using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public double freq = 440.0;
    private double baseFreq = 440.0;
    private double increment;
    private double phase;
    private double sampling_freq = 48000.0;
    private double saw;
    private double sine;
    private double noise;

    [Range (0.0f, 1.0f)]
    public float sineGain;
    [Range(0.0f, 1.0f)]
    public float sawGain;
    [Range(0.0f, 1.0f)]
    public float noiseGain;

    [Range(0.0f, 0.999f)]
    public float pulseWidth;

    public float pitchIncrement;

    public float pitchMin;

    System.Random rand = new System.Random();



    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = freq * 2.0 * Mathf.PI / sampling_freq;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

            // sine wave
            sine = (float)(sineGain * Mathf.Sin((float)phase));

            // square wave
            if (Mathf.Sin((float)phase) + pulseWidth >= 0)
            {
                saw = (float)sawGain * 0.6f;
            }
            else
            {
                saw = (-(float)sawGain) * 0.6f;
            }

            // noise
            noise = (float)(rand.NextDouble() * 2.0 - 1.0) * noiseGain;

            data[i] = (float)sine + (float)saw + (float)noise;


            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            freq += pitchIncrement;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            freq -= pitchIncrement;
        }
        else
        {
            if (freq < baseFreq)
            {
                freq += pitchIncrement;
            }
            else if (freq > baseFreq)
            {
                freq -= pitchIncrement;
            }
        }

        freq = freq < pitchMin ? pitchMin : freq;
    }
}
