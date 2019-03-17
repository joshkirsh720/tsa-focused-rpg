using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform cam;
    void Start()
    {
        if(PlayerController.lastloc == 1)
        {
            cam.position = new Vector3(-1.026f, 2.795953f, -10);
            player.position = new Vector3(-0.9860001f, 3.577996f, -1);
        }
        if (PlayerController.lastloc == 2)
        {
            cam.position = new Vector3(-1.026f, -2.939898f, -10);
            player.position = new Vector3(-1.026f, -3.521998f, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
