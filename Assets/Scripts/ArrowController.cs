using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int knockback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var a = rb.velocity;
            int x = Math.Sign(a.x);
            int y = Math.Sign(a.y);
            Debug.Log(x + " " + y + " " + knockback);
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(3);
            enemy.AddKnockback(new Vector2(x * knockback * 3, y * knockback * 3));
        }
        Destroy(this.gameObject);
    }
}
