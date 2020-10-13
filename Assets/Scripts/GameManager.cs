using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;

    public bool GameHasStarted;

    public Animator transition;
    public float transisitionTime = 1;

    public AudioMixerSnapshot In;
    public AudioMixerSnapshot Out;

    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) * 2 + StartSpeed;
        }

        if ( !GameHasStarted && Input.GetAxis("Vertical") > 0.9f)
        {
            Debug.Log(GameHasStarted);
            CallNextScene();
        }
    }

    public void CallNextScene()
    {
        GameHasStarted = true;
        Score = 0;
        StartCoroutine
        (
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
        );
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("StartFade");
        Out.TransitionTo(.5f);

        yield return new WaitForSeconds(transisitionTime);

        SceneManager.LoadScene(levelIndex);
        transition.SetTrigger("EndFade");
        In.TransitionTo(.5f);
    }
}
