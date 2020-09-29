using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float BaseSpeed;

    void Update()
    {
        transform.Translate(Vector3.right * BaseSpeed * Time.deltaTime);
    }
}
