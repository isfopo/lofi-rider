using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float BaseSpeed;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BaseSpeed);
    }
}
