using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject Object;
    public Transform CameraPosition;

    public float BaseSpeed;
    public GameManager gameManager;

    public Vector2 RandomGenerationRange;

    void Start()
    {
        ObjectMaker();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * gameManager.GlobalSpeed * Time.deltaTime);

        GameObject cs = GameObject.Find(Object.name);

        if (CameraPosition.position.x - cs.transform.position.x > 100)
        {
            Destroy(cs);
        }
    }

    void ObjectMaker()
    {
        GameObject clone = Instantiate(Object, transform.position, Quaternion.identity);
        clone.name = Object.name;

        clone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Invoke(
            nameof(ObjectMaker),
            Random.Range(
                RandomGenerationRange.x * gameManager.GlobalSpeed,
                RandomGenerationRange.y * gameManager.GlobalSpeed
            )
        );
    }
}
