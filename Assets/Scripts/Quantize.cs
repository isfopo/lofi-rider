using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Quantize : MonoBehaviour
{
    public int BPM;
    private uint _128noteCount;
    private int divisor;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Count(1.875f / BPM));
    }

    private IEnumerator Count(float SecondsToWait)
    {
        _128noteCount++;
        yield return new WaitForSeconds(SecondsToWait);
        StartCoroutine(Count(SecondsToWait));
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
