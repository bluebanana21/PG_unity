using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2.0f;
    float nextAttackTime = 0f;

    public LayerMask enemyLayers;

    
    void Update()
    {
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        if (Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
            
        }


    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {

        return; 
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
