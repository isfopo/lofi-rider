using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] Objects;
    public Transform CameraPosition;

    public float BaseSpeed;

    public Vector2 RandomGenerationRange;

    void Start()
    {
        ObstacleMaker();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * gameManager.GlobalSpeed * Time.deltaTime);

        GameObject cs = GameObject.Find("Obstacle");

        if (CameraPosition.position.x - cs.transform.position.x > 100 )
        {
            // add to score here
            Destroy(cs);
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