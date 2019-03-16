using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    private int introlevel = 0;
    bool zpressed;
    bool intro1run;
    bool intro0run;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey("z") == true)
        {
            zpressed = true;

        }
        else
        {
            zpressed = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        text = collision.gameObject.GetComponent<PlayerText>();
        player = collision.gameObject.GetComponent<PlayerController>();
        if (zpressed == true)
        {

            if (introlevel == 0 && intro0run == false)
            {
                StartCoroutine(intro0());

            }
            if (introlevel == 1 && intro1run == false)
            {
                StartCoroutine(intro1());
            }


        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {

        text = collision.gameObject.GetComponent<PlayerText>();
        player = collision.gameObject.GetComponent<PlayerController>();
        if (zpressed == true)
        {

            if(introlevel == 0 && intro0run == false)
            {
                StartCoroutine(intro0());
               
            }
            if(introlevel == 1 && intro1run == false)
            {
                StartCoroutine(intro1());
            }

         
        }
       
    }

    public IEnumerator intro0()
    {

        //do stuff

        //wait for space to be pressed
        intro0run = true;
        player.locked = true;
        StartCoroutine(text.print(" <i>You talk to the messenger</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while(PlayerText.printdone == false)
        {
            yield return null;
        }
       
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Hey those caves up there are pretty cool huh", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I just saw a bunch of trolls go in there", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }

        StartCoroutine(text.print("", .0f));
        player.locked = false;
        introlevel = 1;
        intro0run = false;
        //do stuff once space is pressed

    }

    public IEnumerator intro1()
    {
        print("intro");
        player.locked = true;
        intro1run = true;
        StartCoroutine(text.print("They seemed like they were in a hurry", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("", .0f));
        player.locked = false;
        yield return new WaitForSeconds(1f);
        intro1run = false;

       
    }


}
