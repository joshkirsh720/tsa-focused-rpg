using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xVel = 0;
        float yVel = 0;

        if (Input.GetKey(KeyCode.UpArrow)) yVel = speed;
        if (Input.GetKey(KeyCode.DownArrow)) yVel = -speed;
        if (Input.GetKey(KeyCode.LeftArrow)) xVel = -speed;
        if (Input.GetKey(KeyCode.RightArrow)) xVel = speed;

        rb.velocity = new Vector2(xVel, yVel);
    }
}
