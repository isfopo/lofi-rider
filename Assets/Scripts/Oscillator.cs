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
    private double noise;

    public AudioLowPassFilter lowPassFilter;
    public AudioChorusFilter chorusFilter;

    [Range(0.0f, 1.0f)]
    public float sawGain;
    [Range(0.0f, 1.0f)]
    public float noiseGain;

    [Range(0.0f, 0.999f)]
    public float pulseWidth;

    public float tIncrement;
    private float t = 0.5f;

    public float freqRatio = 10; // over 1

    System.Random rand = new System.Random();

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = freq * 2.0 * Mathf.PI / sampling_freq;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

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

            data[i] = (float)saw + (float)noise;


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
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            t += tIncrement;
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            t -= tIncrement;
        }
        else
        {
            if (t < 0.55f)
            {
                t += tIncrement;
            }
            else if (t > 0.45f)
            {
                t -= tIncrement;
            }
        }

        t = t < 0 ? 0 : t;
        t = t > 1 ? 1 : t;

        freq = Mathf.Lerp((float)freq - freqRatio / 2, (float)freq + freqRatio/2, t);

        pulseWidth = Mathf.SmoothStep(.25f, .75f, t);
        noiseGain = Mathf.Lerp(0.0f, 0.3f, t);
        chorusFilter.rate = Mathf.SmoothStep(0, 1, t);
        lowPassFilter.cutoffFrequency = Mathf.LerpUnclamped(10, 11000, t);
    }
}
