using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private float sampling_freq = 48000.0f; // can a get unity system sampling freq?
    private float sawPhase;
    private float sinPhase;

    private float freq = 440.0f;
    private float lfoFreq;
    private float pulseWidth;
    public AudioLowPassFilter lowPassFilter;
    public AudioChorusFilter chorusFilter;

    public Vector2 freqRange;
    public Vector2 lfoFreqRange;
    public Vector2 pusleWidthRange;
    public Vector2 lpRange;
    public Vector2 chorusRateRange;
    public Vector2 chorusDepthRange;

    public float tIncrement;
    private float t = 0.5f;

    private GameObject forwardBound;
    private GameObject backBound;
    private float playerPosition;

    private float rightGain;
    private float leftGain;

    private void Start()
    {
        forwardBound = GameObject.FindGameObjectWithTag("ForwardBound");
        backBound = GameObject.FindGameObjectWithTag("BackBound");
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = Saw(freq * Sin(lfoFreq));

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            // right channel
            //data[i] *= (playerPosition * 10) + 1;

            // left channel
            //data[i + 1] *= Mathf.Abs(playerPosition * 10) + 1;

        }
    }

    private float Saw(float freq)
    {
        sawPhase += freq * 2.0f * Mathf.PI / sampling_freq;
 
        if (sawPhase > (Mathf.PI * 2))
        {
            sawPhase = 0.0f;
        }

        if (Mathf.Sin(sawPhase) + pulseWidth >= 0)
        {
            return 0.6f;
        }
        else
        {
            return -0.6f;
        }
    }

    private float Sin(float freq)
    {
        sinPhase += freq * 2.0f * Mathf.PI / sampling_freq;

        if (sinPhase > (Mathf.PI * 2))
        {
            sinPhase = 0.0f;
        }

        return Mathf.Sin(sinPhase);
    }


    void Update()
    {
        ControlT();
        ControlParams();
    }

    void ControlParams()
    {
        freq = Mathf.SmoothStep(freqRange.x, freqRange.y, t);

        lfoFreq = Mathf.SmoothStep(lfoFreqRange.x, lfoFreqRange.y, t);

        pulseWidth = Mathf.SmoothStep(pusleWidthRange.x, pusleWidthRange.y, t);

        lowPassFilter.cutoffFrequency = Mathf.LerpUnclamped(lpRange.x, lpRange.y, t);

        chorusFilter.rate = Mathf.SmoothStep(chorusRateRange.x, chorusRateRange.y, t);

        chorusFilter.depth = Mathf.SmoothStep(chorusDepthRange.x, chorusDepthRange.y, t);
    }

    void ControlT()
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
        t = Mathf.Clamp(t, 0.0f, 1.0f);
    }
}


// https://www.youtube.com/watch?v=GqHFGMy_51c&ab_channel=DanoKablamo