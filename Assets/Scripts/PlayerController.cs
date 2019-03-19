using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public bool haskey;
    public bool locked;
    public static int lastloc;
    public PlayerText text;
    public bool deadg;
    public Rigidbody2D arrow;
    public int arrowSpeed;
    public float hitDistance, hitRadius, knockbackForce, attackDelay;
    private float lastAttackTime = -2;
    public int hitDamage;

    public int health = 3;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    public IEnumerator shootside()
    {
        yield return new WaitForSeconds(.5f);
        Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(transform.localScale.x * .2f, -.05f, 0), transform.rotation);
        clone.gameObject.SetActive(true);
        clone.velocity = new Vector3(transform.localScale.x * arrowSpeed, 0, 0);
        clone.transform.Rotate(0, 0, transform.localScale.x * -90);
    }
    public IEnumerator shootup()
    {
        yield return new WaitForSeconds(.5f);
        Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(0, .2f, 0), transform.rotation);
        clone.gameObject.SetActive(true);
        clone.velocity = new Vector3(0, arrowSpeed, 0);
    }
    public IEnumerator shootdown()
    {
        yield return new WaitForSeconds(.5f);
        Rigidbody2D clone = Instantiate(arrow, transform.position + new Vector3(0, -.27f, 0), transform.rotation);
        clone.gameObject.SetActive(true);
        clone.velocity = new Vector3(0, -arrowSpeed, 0);
        clone.transform.Rotate(0, 0, 180);
    }
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
        bool isSidePunch = false;
        bool isSideBow = false;
        bool isDownBow = false;
        bool isUpBow = false;

        bool isUpPunch = false;
        bool isDownPunch = false;

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
        else if (yVel > 0)
        {
            isUpWalking = true;
            currentstate = 2;
        }
        else if (yVel < 0)
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
            else if (currentstate == 3)
            {
                isDownIdle = true;
            }
        }


        if ((Time.time - timefromattack) < waitTime && ChestController.bow || Time.time - lastAttackTime < attackDelay)
        {
            xVel = 0;
            yVel = 0;

        }
        else if (Input.GetKey("space") && ChestController.bow)
        {

            if (currentstate == 1)
            {
                StartCoroutine(shootside());
                isSideBow = true;
            }
            else if (currentstate == 2)
            {
                StartCoroutine(shootup());
                isUpBow = true;
            }
            else if (currentstate == 3)
            {
                StartCoroutine(shootdown());
                isDownBow = true;
            }
            timefromattack = Time.time;
        }
        else if (Input.GetKey("x") && Time.time - lastAttackTime > attackDelay)
        {
            print("attack");
            var hitLocation = transform.position;
            Vector2 knockbackVector = new Vector2();
            if (currentstate == 1)
            {
                hitLocation += new Vector3(transform.localScale.x * hitDistance, 0);
                knockbackVector.x = transform.localScale.x * knockbackForce * 5;
                isSidePunch = true;


                var hit = Physics2D.OverlapCircleAll(hitLocation, hitRadius);
                foreach (var collision in hit)
                {
                    if (collision.gameObject.tag == "Enemy" && collision.gameObject.name != "Boss")
                    {
                        var enemy = collision.gameObject.GetComponent<EnemyController>();
                        enemy.TakeDamage(hitDamage);
                        enemy.AddKnockback(knockbackVector);
                    }
                }

                lastAttackTime = Time.time;
            }
        }

        //set x and y signs to keep track of which direction the player is facing


        //Debug.Log("xSign: " + xSign + " ySign: " + ySign);
        //Debug.Log("xVel: " + xVel + " yVel: " + yVel);

        if (locked == false && deadg == false)
        {
            rb.velocity = new Vector2(xVel, yVel);
            anim.SetBool("isSidePunch", isSidePunch);
            anim.SetBool("isDownPunch", isDownPunch);
            anim.SetBool("isUpPunch", isUpPunch);
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
            rb.velocity = new Vector2(0, 0);
            if (isWalking)
            {
                anim.SetBool("isSideIdle", true);
            }
            else if (isUpWalking)
            {
                anim.SetBool("isUpIdle", true);
            }
            else if (isDownWalking)
            {
                anim.SetBool("isDownIdle", true);
            }
            else
            {
                anim.SetBool("isSideBow", isSideBow);
                anim.SetBool("isDownBow", isDownBow);
                anim.SetBool("isUpBow", isUpBow);
                anim.SetBool("isSidePunch", isSidePunch);
                anim.SetBool("isDownPunch", isUpPunch);
                anim.SetBool("isUpPunch", isDownPunch);
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

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHearts();
        if (!IsAlive()) Die();
    }
    public bool IsAlive()
    {
        return health > 0;
    }
    private void Die()
    {

        //replace with some cool death code idk
        deadg = true;
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(dead());

    }
    private void UpdateHearts()
    {
        if (health == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
           
        
        }
        else if (health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
    }

    public IEnumerator dead()
    {
        
        print("dead");
        StartCoroutine(text.print(" You Died. Press Z to respawn", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        print("done");
       
        StartCoroutine(text.print("", .0f));
        text.Box.SetActive(false);
        if (PlayerController.lastloc == 1)
        {
            PlayerController.lastloc = 0;
            SceneManager.LoadScene("Dungeon");
        }
        else if (PlayerController.lastloc == 2)
        {
            PlayerController.lastloc = 0;
            SceneManager.LoadScene("hallway");
        }
        else if (PlayerController.lastloc == 3)
        {
            PlayerController.lastloc = 0;
            SceneManager.LoadScene("fight");
        }
        else
        {
            PlayerController.lastloc = 0;
            SceneManager.LoadScene("doublefight");
        }
    }
}