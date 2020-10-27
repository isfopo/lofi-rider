using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using System;

public class Quantize : MonoBehaviour
{
    private int _128noteCount;
    private int divisor;

    [InfoBox("Add global BPM", EInfoBoxType.Normal)]
    public int BPM;
    public int Beat;
    public int Bar;

    private void Start()
    {
        if ( BPM == 0 )
        {
            Debug.LogError("BPM must be greater than zero!");
        }
    }

    private void Update()
    {
        _128noteCount = Mathf.FloorToInt(Time.time / (1.875f / BPM));

        Beat = (_128noteCount / 32 % 4) + 1;

        Bar = (_128noteCount / 128) + 1;

    }    
    
    // ===================================================

    public void Play(AudioSource source, string beatCode, bool IsRepeating = false, int offset = 0)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitTo(source, divisor, true, IsRepeating, offset));
    }

    public void Stop(AudioSource source, string beatCode, int offset = 0)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitTo(source, divisor, false, false, offset));
    }

    public void StopRepeat(AudioSource source)
    {
        source.loop = false;
    }

    private IEnumerator WaitTo(AudioSource source, int divisor, bool shouldPlay, bool IsRepeating = false, int offset = 0)
    {
        yield return new WaitUntil(() => _128noteCount % divisor == (divisor * offset));

        if (shouldPlay)
        {
            source.Play();

            if (IsRepeating)
            {
                source.loop = true;
            }
        }
        else
        {
            source.Stop();
            yield return null;
        }
    }

    // ===================================================

    public void QuantizeCall(Action call, string beatCode, int offset = 0)
    {
        divisor = GetDivisorFromCode(beatCode);
        StartCoroutine(WaitToCall(call, divisor, offset));
    }

    private IEnumerator WaitToCall(Action call, int divisor, int offset = 0)
    {
        yield return new WaitUntil(() => _128noteCount % divisor == (divisor * offset));

        call();
    }

    // ===================================================

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
            throw new Exception("Code must end with 'n' for note or 'b' for bar");
        }
    }
}
