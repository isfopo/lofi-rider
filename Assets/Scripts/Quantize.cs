using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Quantize : MonoBehaviour
{
    public int BPM;
    public int _128noteCount; // change to private on release
    public int Beat;
    public int Bar;
    public AudioSource PlayOnStart;

    private int divisor;

    private void Start()
    {
        // Play(PlayOnStart, "1n");
    }

    private void Update()
    {
        _128noteCount = Mathf.FloorToInt(Time.time / (1.875f / BPM));

        Beat = (_128noteCount / 32 % 4) + 1;

        Bar = (_128noteCount / 128) + 1;
    }    
    
    // ===================================================

    public void Play(AudioSource source, string beatCode, bool IsRepeating = false)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitTo(source, divisor, true, IsRepeating));
    }

    public void Stop(AudioSource source, string beatCode)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitTo(source, divisor, false));
    }

    private IEnumerator WaitTo(AudioSource source, int divisor, bool shouldPlay, bool IsRepeating = false)
    {
        yield return new WaitUntil(() => _128noteCount % divisor == 0);

        if (shouldPlay)
        {
            source.Play();
        }
        else
        {
            source.Stop();
            yield return null;
        }

        if (IsRepeating && shouldPlay)
        {
            StartCoroutine(WaitTo(source, divisor, shouldPlay, IsRepeating));
        }
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
