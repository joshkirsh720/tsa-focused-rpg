using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D bx;
    public double spawntime;
    public PlayerText text;
    public PlayerController player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time > (spawntime + 2))
        {
            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().haskey = true;
                print("haskey");
                StartCoroutine(keypick());
               
            }
        }
       
    }
    public IEnumerator keypick()
    {
        //wait for space to be pressed

        player.locked = true;
        StartCoroutine(text.print(" <i>You found a key</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }

        StartCoroutine(text.print("", .0f));
        text.Box.SetActive(false);
        player.locked = false;
        Destroy(this.gameObject);
    }
}

