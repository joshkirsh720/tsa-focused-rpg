using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    private float forceAmount;
    public float enemySpeed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follow player
        int xSign = Math.Sign(player.transform.position.x - transform.position.x);
        int ySign = Math.Sign(player.transform.position.y - transform.position.y);
        rb.velocity = new Vector2(xSign * enemySpeed, ySign * enemySpeed);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(!IsAlive())
        {
            Die();
        }
    }
    public void AddKnockback(Vector2 force)
    {
        
        rb.AddForce(force);
    }



    bool IsAlive()
    {
        return health > 0;
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}
