using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject Object;
    public GameObject Camera;

    public float BaseSpeed;
    public GameManager gameManager;

    public Vector2 RandomGenerationRange;

    void Start()
    {
        ObjectMaker();
        gameManager = FindObjectOfType<GameManager>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.Translate(Vector3.right * gameManager.GlobalSpeed * Time.deltaTime);

        GameObject cs = GameObject.Find("Object");
        Debug.Log(cs.name);

        if (Camera != null)
        {
            if (Camera.transform.position.x - cs.transform.position.x > 100)
            {
                Destroy(cs);
            }
        }
    }

    void ObjectMaker()
    {
        GameObject clone = Instantiate(Object, transform.position, Quaternion.identity);
        clone.name = "Object";

        clone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Invoke(
            nameof(ObjectMaker),
            Random.Range(
                RandomGenerationRange.x * 8,
                RandomGenerationRange.y * 8
            )
        );
    }
}
