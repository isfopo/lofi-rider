using System.Collections;
using UnityEngine;

public class BGShift : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BG1" || other.gameObject.tag == "BG2")
        {
            MovePosition(other.gameObject.tag, other);
        }
    }

    void MovePosition(string tag, Collider2D other)
    {
        GameObject[] otherObject = GameObject.FindGameObjectsWithTag(tag);

        float width = ((BoxCollider2D)other).size.x;


        Vector3 pos = other.transform.position;
        pos.x += width * 2.0f;
        other.transform.position = pos;
    }
}
