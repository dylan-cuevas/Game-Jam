using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform punchPoint;
    public Transform kickPoint;
    public float punchRange = 0.6f;
    public float kickRange = 0.6f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Punch"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetButtonDown("Kick"))
            {
                Kick();
                nextAttackTime = Time.time + 1f / attackRate;

            }

        }
    }

    void Attack()
    {
        animator.SetTrigger("Punch");

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }


    }

    void Kick()
    {
        animator.SetTrigger("Kick");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
            return;

        if (kickPoint == null)
            return;

        Gizmos.DrawWireSphere(punchPoint.position, punchRange);
        Gizmos.DrawWireSphere(kickPoint.position, kickRange);

    }
}
