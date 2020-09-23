using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0 && GameObject.FindGameObjectWithTag("Player").transform.position.y < 0.1)
        {
            animator.SetTrigger("isJumping");
        }
    }
}
