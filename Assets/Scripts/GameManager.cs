using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float GlobalSpeed;
    public float StartSpeed;
    public string[] SceneNames;

    public bool GameHasStarted;

    public Animator transition;
    public float transisitionTime = 1;

    void Update()
    {
        Score = Score <= 1 ? 1 : Score;

        if (GameHasStarted)
        {
            GlobalSpeed = Mathf.Log(Score, 2) + StartSpeed;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CallNextScene();
        }
    }

    public void CallNextScene()
    {
        GameHasStarted = true;
        StartCoroutine(
            LoadScene(
                Random.Range(1, SceneManager.sceneCountInBuildSettings - 1))
            );
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(transisitionTime);

        transition.SetTrigger("EndFade");
        SceneManager.LoadScene(levelIndex);
    }
}
