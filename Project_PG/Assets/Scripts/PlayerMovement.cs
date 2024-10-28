using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float horizontal;
    private float vertical;
    private float speed = 160f;
    private float interactionRadius = 2f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    private DialogueAdvanceInput dialogueInput;

    void Start()
    {
        dialogueInput = FindObjectOfType<DialogueAdvanceInput>();
        dialogueInput.enableActionOnStart = false;
    }

    void Update()
    {
        
        
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CheckForNearbyNPC();
            Debug.Log("Testing...");
        }
        

        if (dialogueInput.enabled)
        {
            dialogueInput.enabled = false;
            
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed *Time.deltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = false;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void CheckForNearbyNPC()
    {
        var allParticipants = new List<NPCInteractable>(FindObjectsOfType<NPCInteractable>());
        var target = allParticipants.Find(delegate (NPCInteractable p)
        {
            return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
            (p.transform.position - this.transform.position)// is in range?
            .magnitude <= interactionRadius;
        });
        if (target != null)
        {
            // Kick off the dialogue at this node.
            FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
            // reenabling the input on the dialogue
            
        }
    }
}
