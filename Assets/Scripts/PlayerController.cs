using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isWalking;
    public bool isIdle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xVel = 0;
        float yVel = 0;
        isWalking = false;
        isIdle = false;

        if (Input.GetKey(KeyCode.UpArrow)) yVel = speed;
        if (Input.GetKey(KeyCode.DownArrow)) yVel = -speed;
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            xVel = -speed;
            transform.localScale = new Vector3(-20, 20, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xVel = speed;
            transform.localScale = new Vector3(20, 20, 1);
        }
        if (yVel != 0 || xVel != 0)
        {
            isWalking = true;
            
        }
        else
        {
            isIdle = true;
            
        }
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isWalking", isWalking);
        rb.velocity = new Vector2(xVel, yVel);

        
    }
}
