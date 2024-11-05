using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHelath = 100;
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;

    private int currentHealth;

    public Transform player;
    public bool isFlipped = false;
   
    void Start()
    {
        currentHealth = maxHelath; 
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        } 

        Debug.Log(currentHealth); 
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        Debug.Log(this.name + " is dead");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;

        } else if (transform.position.x < player.position.x && !isFlipped)
        {

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;

        }
    }
}
