using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpHeight;

    public float BaseSpeed;
    public float SpeedMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * (BaseSpeed + (Input.GetAxis("Horizontal") * SpeedMultiplier)));

        if (Input.GetAxis("Vertical") > 0 && GameObject.FindGameObjectWithTag("Player").transform.position.y < 0.1 )
        {
            rb.velocity = new Vector3(1, jumpHeight, 0);
        }
    }
}
