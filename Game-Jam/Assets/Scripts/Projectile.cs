using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int attackDamage = 10;

    private Transform playerSpot;
    private Vector2 target;

    void Start()
    {
        playerSpot = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(playerSpot.position.x, playerSpot.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(attackDamage);
            DestroyProjectile();
        }

       
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
