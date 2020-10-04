using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpHeight;

    public GameManager gameManager;
    public GameObject Camera;

    public float BaseSpeed;
    public float SpeedMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * (gameManager.GlobalSpeed + (Input.GetAxis("Horizontal") * SpeedMultiplier)));

        if (Input.GetAxis("Vertical") > 0 && GameObject.FindGameObjectWithTag("Player").transform.position.y < 0.1 )
        {
            rb.velocity = new Vector3(1, jumpHeight, 0);
        }

        if (Camera.transform.position.y - transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
