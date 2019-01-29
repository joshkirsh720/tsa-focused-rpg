using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float dampening = .3f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(player.position - new Vector3(0, 0, 10), transform.position, ref velocity, dampening);
        
    }
}
