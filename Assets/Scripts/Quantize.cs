using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Quantize : MonoBehaviour
{
    public int BPM;
    private int _128noteCount;
    private int msCount;
    public uint Beat;
    public uint Bar;

    private int divisor;

    private void Start()
    {
        msCount = 0;
    }

    private void FixedUpdate()
    {
        msCount += 20;
        _128noteCount = Mathf.RoundToInt((float)msCount / (1875.0f / (float)BPM));

        Beat = (uint)((_128noteCount / 32) % 4) + 1;

        Bar = (uint)(_128noteCount / 128) + 1;
    }

    // ===================================================

    public void Play(AudioSource source, string beatCode)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitToPlay(source, divisor));
    }

    private IEnumerator WaitToPlay(AudioSource source, int divisor)
    {
        yield return new WaitUntil(() => _128noteCount % divisor == 0);
        source.Play();
    }

    public void Stop(AudioSource source, string beatCode)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitToStop(source, divisor));
    }

    private IEnumerator WaitToStop(AudioSource source, int divisor)
    {
        yield return new WaitUntil(() => _128noteCount % divisor == 0);

        source.Stop();
    }

    private int GetDivisorFromCode(string beatCode)
    {
        if (beatCode[beatCode.Length - 1] == 'n')
        {
            return 128 / int.Parse(beatCode.Substring(0, beatCode.Length - 1));
        }
        else if (beatCode[beatCode.Length - 1] == 'b')
        {
            return 128 * int.Parse(beatCode.Substring(0, beatCode.Length - 1));
        }
        else
        {
            throw new System.Exception("Code must end with 'n' for note or 'b' for bar");
        }
    }
}
