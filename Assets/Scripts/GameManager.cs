using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;
    public bool inDebug;
    private bool isPaused = false;

    public bool GameHasStarted;

    public Animator transition;
    public float transisitionTime = 1;

    public AudioMixerSnapshot In;
    public AudioMixerSnapshot Out;
    public AudioMixerSnapshot Paused;
    public GameObject PauseScreen;

    private void Start()
    {
        DontDestroyOnLoad(PauseScreen);
    }

    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) * 2 + StartSpeed;
        }

        if ( !GameHasStarted && Input.GetAxis("Vertical") > 0.9f)
        {
            CallNextScene();
        }

        if (Input.GetButtonDown("Fire1") && inDebug)
        {
            CallNextScene();
        }

        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                isPaused = true;
                Paused.TransitionTo(0f);
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                In.TransitionTo(0f);
                PauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void CallNextScene()
    {
        GameHasStarted = true;
        Score = 0;
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            StartCoroutine(LoadScene(1));
        }
        else
        {
            StartCoroutine
            (
                LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
            );
        }
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
