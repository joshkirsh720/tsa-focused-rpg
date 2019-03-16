using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public double[] starting = new double[2];
    public float dampening = .3f;
    private Vector3 velocity = Vector3.zero;
    public double rightXbounds;
    public double leftXbounds;
    public double topYbounds;
    public double botYbounds;
    bool moveTox;
    bool moveToy;
    private void Start()
    {
        rightXbounds = rightXbounds + transform.position.x;
        leftXbounds = transform.position.x - leftXbounds;
        botYbounds = botYbounds + transform.position.y;
        topYbounds = transform.position.y - topYbounds;
    }
  
    // Update is called once per frame
    void LateUpdate()
    {
        moveTox = false;
        moveToy = false;
        if (player.position.x > leftXbounds && player.position.x < rightXbounds)
        {

            moveTox = true;
        }
        if(player.position.y < botYbounds && player.position.y > topYbounds)
        {
            moveToy = true;
        }
        if(moveToy && moveTox)
        {
            transform.position = Vector3.SmoothDamp(player.position - new Vector3(0, 0, 10), transform.position, ref velocity, dampening);
        }
        else if(moveTox)
        {
            transform.position= Vector3.SmoothDamp(new Vector3(player.position.x, transform.position.y, -10), transform.position, ref velocity, dampening);
        } 
        else if(moveToy)
        {
            transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, player.position.y, -10), transform.position, ref velocity, dampening);
        }
    }

    }

