using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] Objects;
    public GameObject Camera;

    public Vector2 RandomGenerationRange;

    void Start()
    {
        ObstacleMaker();
        gameManager = FindObjectOfType<GameManager>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.Translate(Vector3.right * gameManager.GlobalSpeed * Time.deltaTime);

        GameObject cs = GameObject.Find("Obstacle");

        if (Camera != null)
        {
            if (Camera.transform.position.x - cs.transform.position.x > 100 )
            {
                Destroy(cs);
            }
        }
    }

    void ObstacleMaker()
    {
        GameObject clone = Instantiate(Objects[Random.Range(0, Objects.Length)], transform.position, Quaternion.identity);
        clone.name = "Obstacle";
        clone.transform.position = new Vector3(transform.position.x, Random.Range(-2, 2), transform.position.z);
        clone.AddComponent<BoxCollider2D>();
        clone.GetComponent<BoxCollider2D>().isTrigger = true;

        Invoke(nameof(ObstacleMaker), Random.Range(RandomGenerationRange.x, RandomGenerationRange.y));
    }
}