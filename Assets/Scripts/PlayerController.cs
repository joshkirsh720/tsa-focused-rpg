using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Animator anim;
    public int currentstate;
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
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isDownIdle", isDownIdle);
        anim.SetBool("isUpIdle", isUpIdle);
        anim.SetBool("isSideIdle", isSideIdle);
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isUpWalking", isUpWalking);
        anim.SetBool("isDownWalking", isDownWalking);
        rb.velocity = new Vector2(xVel, yVel);

        if(Input.GetKey("space"))
        {
            if (currentstate == 1)
            {
                isSideBow = true;
            }
            else if (currentstate == 2)
            {
                isUpBow = true;
            }
            else if (currentstate == 3)
            {
                isDownBow = true;
            }
        }
        anim.SetBool("isSideBow", isSideBow);   
        anim.SetBool("isDownBow", isDownBow);
        anim.SetBool("isUpBow", isUpBow);
    }
}
