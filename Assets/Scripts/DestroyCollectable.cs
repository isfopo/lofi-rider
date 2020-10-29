using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    public GameObject CollectEffect;
    private GameObject instance;

    public void Collect()
    {
        instance = Instantiate(CollectEffect, transform.position, transform.rotation);

        instance.GetComponent<CollectEffect>().CreateEffect();

        Destroy(gameObject);
    }
}
