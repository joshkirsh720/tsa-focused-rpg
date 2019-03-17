using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Animator anim;
    public int currentstate;
    public float timefromattack;
    public float waitTime = 1.5f;
    public float xVel;
    public float yVel;
    public int xSign, ySign;
    public int amountofkeys;
 
    public bool locked;
    public static int lastloc;


    public Rigidbody2D arrow;
    public int arrowSpeed;
    public float hitDistance, hitRadius, knockbackForce, attackDelay;
    private float lastAttackTime;
    public int hitDamage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentstate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
      
        float xVel = 0;
        float yVel = 0;

        bool isUpWalking = false;
        bool isDownWalking = false;
        bool isWalking = false;
        
        bool isIdle = false;
        bool isSideIdle = false;
        bool isDownIdle = false;
        bool isUpIdle = false;

        bool isSideBow = false;
        bool isDownBow = false;
        bool isUpBow = false;


        if (Input.GetKey(KeyCode.UpArrow)) yVel = speed;
        if (Input.GetKey(KeyCode.DownArrow)) yVel = -speed;
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            xVel = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xVel = speed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (yVel == 0 && xVel != 0)
        {
            isWalking = true;
            currentstate = 1;
        }
        else if(yVel > 0)
        {
            isUpWalking = true;
            currentstate = 2;
        }
        else if(yVel < 0)
        {
            isDownWalking = true;
            currentstate = 3;
        }
        else
        {
            if (currentstate == 0)
            {
                isIdle = true;
            }
            if (currentstate == 1)
            {
                isSideIdle = true;
            }
            else if (currentstate == 2)
            {
                isUpIdle = true;
            }
            else if(currentstate == 3)
            {
                isDownIdle = true;
            }
        }


        if ((Time.time - timefromattack) < waitTime && ChestController.bow)
        {
            xVel = 0;
            yVel = 0;

        }
        else if (Input.GetKey("space") && ChestController.bow) { 
        
            if (currentstate == 1)
            {
                Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(transform.localScale.x * .2f, 0, 0), transform.rotation);
                clone.gameObject.SetActive(true);
                clone.velocity = new Vector3(transform.localScale.x * arrowSpeed, 0, 0);
                clone.transform.Rotate(0,0,transform.localScale.x * -90);
                
                
                isSideBow = true;
            }
            else if (currentstate == 2)
            {
                Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(0, .2f, 0), transform.rotation);
                clone.gameObject.SetActive(true);
                clone.velocity = new Vector3(0, arrowSpeed, 0);
                isUpBow = true;
            }
            else if (currentstate == 3)
            {
                Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(0, -.25f, 0), transform.rotation);
                clone.gameObject.SetActive(true);
                clone.velocity = new Vector3(0, -arrowSpeed, 0);
                clone.transform.Rotate(0, 0, 180);
                isDownBow = true;
            }
            timefromattack = Time.time;
        }
        else if(Input.GetKey("x") && Time.time - lastAttackTime > attackDelay)
        {
            var hitLocation = transform.position;
            Vector2 knockbackVector = new Vector2();
            if(currentstate == 1)
            {
                hitLocation += new Vector3(transform.localScale.x * hitDistance, 0);
                knockbackVector.x = transform.localScale.x * knockbackForce;
            }
            else if(currentstate == 2)
            {
                hitLocation += new Vector3(0, hitDistance);
                knockbackVector.y = knockbackForce;
            }
            else if(currentstate == 3)
            {
                hitLocation += new Vector3(0, -hitDistance);
                knockbackVector.y = knockbackForce;
            }

            var hit = Physics2D.OverlapCircleAll(hitLocation, hitRadius);
            foreach(var collision in hit)
            {
                if(collision.gameObject.tag == "Enemy")
                {
                    var enemy = collision.gameObject.GetComponent<EnemyController>();
                    enemy.TakeDamage(hitDamage);
                    enemy.AddKnockback(knockbackVector);
                }
            }

            lastAttackTime = Time.time;
        }

        //set x and y signs to keep track of which direction the player is facing
        if(xVel != 0 || yVel != 0)
        {
            xSign = Math.Sign(xVel);
            ySign = Math.Sign(yVel);

        
        }

        //Debug.Log("xSign: " + xSign + " ySign: " + ySign);
        //Debug.Log("xVel: " + xVel + " yVel: " + yVel);

        if (locked == false)
        {
            rb.velocity = new Vector2(xVel, yVel);
            anim.SetBool("isSideBow", isSideBow);
            anim.SetBool("isDownBow", isDownBow);
            anim.SetBool("isUpBow", isUpBow);
            anim.SetBool("isIdle", isIdle);
            anim.SetBool("isDownIdle", isDownIdle);
            anim.SetBool("isUpIdle", isUpIdle);
            anim.SetBool("isSideIdle", isSideIdle);
            anim.SetBool("isWalking", isWalking);
            anim.SetBool("isUpWalking", isUpWalking);
            anim.SetBool("isDownWalking", isDownWalking);
        }
        else
        {
            if(isWalking)
            {
                anim.SetBool("isSideIdle", true);
            }
            else if(isUpWalking)
            {
                anim.SetBool("isUpIdle", true);
            }
            else if(isDownWalking)
            {
                anim.SetBool("isDownIdle", true);
            }
            else
            {
                anim.SetBool("isSideBow", isSideBow);
                anim.SetBool("isDownBow", isDownBow);
                anim.SetBool("isUpBow", isUpBow);
                anim.SetBool("isIdle", isIdle);
                anim.SetBool("isDownIdle", isDownIdle);
                anim.SetBool("isUpIdle", isUpIdle);
                anim.SetBool("isSideIdle", isSideIdle);
                anim.SetBool("isWalking", isWalking);
                anim.SetBool("isUpWalking", isUpWalking);
                anim.SetBool("isDownWalking", isDownWalking);
            }
        }

    }
}