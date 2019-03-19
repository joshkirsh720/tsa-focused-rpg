using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private float spikeCooldownStart = 0;
    public double sinceattack;
    // Start is calld before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.timeSinceLevelLoad - spikeCooldownStart > .5)
        {
            var time = Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad;
            if (.4 < time && time < .6 && Time.time > (sinceattack + .5))
            {
                Debug.Log("Spike " + time);
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
                spikeCooldownStart = Time.timeSinceLevelLoad;
                sinceattack = Time.time;
            }
            else return;
        }
    }
}
