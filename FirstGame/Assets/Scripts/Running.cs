using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Running : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private bool IsFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    private Animator animator;

    public float leftBoundary = -10f;
    public float rightBoundary = 10f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if (Mathf.Abs(horizontal) > 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        UpdateMovementBounds();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (IsFacingRight && horizontal < 0f || !IsFacingRight && horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void UpdateMovementBounds()
    {
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
            animator.SetFloat("Speed", 0f);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
            animator.SetFloat("Speed", 0f);
        }
    }
}