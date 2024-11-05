using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;

    public Animator animator;

    [SerializeField] private float speed = 160f; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

   
    void Update()
    {
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed *Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
