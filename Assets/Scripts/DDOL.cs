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
        if (shouldReset)
        {
            OriginalPosition = transform.position;
        }
        
        DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                  && GameObject.Find(gameObject.name) != gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }

    private void Update()
    {
        if (shouldReset)
        {
            currentScene = SceneManager.GetActiveScene().name;
            if (lastScene != currentScene)
            {
                transform.position = OriginalPosition;
            }
            lastScene = currentScene;
        }
    }
}
