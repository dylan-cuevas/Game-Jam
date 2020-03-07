using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public Door door;

    public int maxHealth = 100;
    int currentHealth;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public int attackRange = 35;
    public bool inRange;

    public GameObject projectile;
    public Transform player;


    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        inRange = distance < attackRange;

        if (timeBtwShots <= 0 && inRange)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died.");

        door.addCount();
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
        
    }
  
}
