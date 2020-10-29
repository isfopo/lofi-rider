using UnityEngine;

public class LowerScore : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Obstacle")
        {
            gameManager.Score--;
        }
        else if (other.name == "Collectable")
        {
            GameObject otherObject = other.gameObject;
            DestroyCollectable destroyCollectable = otherObject.GetComponent<DestroyCollectable>();
            destroyCollectable.Collect();


            gameManager.Score++;
        }
    }
}
