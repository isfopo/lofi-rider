using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource damageSound;
    public float secondsToReset;

    private bool isResetting = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Obstacle")
        {
            if (!isResetting)
            {
                damageSound.Play();
                gameManager.Score--;
                isResetting = true;
                StartCoroutine(ResetDamage(secondsToReset));
            }
        }
        else if (other.name == "Collectable")
        {
            GameObject otherObject = other.gameObject;
            DestroyCollectable destroyCollectable = otherObject.GetComponent<DestroyCollectable>();
            destroyCollectable.Collect();


            gameManager.Score++;
        }
    }

    private IEnumerator ResetDamage(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);

        isResetting = false;
    }
}
