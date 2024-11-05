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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHelath; 
    }

    // Update is called once per frame
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
}
