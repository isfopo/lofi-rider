using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public bool shouldReset;
    private Vector3 OriginalPosition;
    private string lastScene;
    private string currentScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        OriginalPosition = transform.position;
    }

    private void Update()
    {
        if (shouldReset)
        {
            currentScene = SceneManager.GetActiveScene().name;
            if (lastScene != currentScene)
            {
                Debug.Log("New scene");
                transform.position = OriginalPosition;
            }
            lastScene = currentScene;
        }
    }
}
