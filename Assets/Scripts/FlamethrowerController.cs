using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerController : MonoBehaviour
{
    public Animator anim;
    private bool active;
    private float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RunFlamethrower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunFlamethrower()
    {
        while (true)
        {
            anim.enabled = true;
            active = true;
            yield return new WaitForSeconds(3);
            anim.enabled = false;
            active = false;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && active && Time.time - cooldown > 1)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            cooldown = Time.time;
        }
    }

}
