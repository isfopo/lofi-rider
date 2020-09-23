using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGShift : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        float width = ((BoxCollider2D)other).size.x;
        Vector3 pos = other.transform.position;

        pos.x += width * 1.99f;

        if (other.gameObject.tag == "BG1")
        {
            other.transform.position = pos;
        }
        if (other.gameObject.tag == "BG2")
        {
            other.transform.position = pos;
        }
    }
}
