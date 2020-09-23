using UnityEngine;

public class LandController : MonoBehaviour
{
    public float moveMultiplier;

    public float DownSpeed;

    public float LowerLimit;
    public float UpperLimit;

    void Update()
    {
        Debug.Log("update");

        if ( Input.GetAxis("Vertical") < 0 )
        {
            if (transform.position.y >= LowerLimit)
            {
                transform.Translate(new Vector3(0, (DownSpeed * -1), 0));
            }
        }
        else if ( Input.GetAxis("Vertical") > -1 )
        {
            if (transform.position.y <= UpperLimit)
            {
                transform.Translate(new Vector3(0, DownSpeed, 0));
            }
        }
    }
}
