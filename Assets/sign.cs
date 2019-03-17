using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    private int introlevel = 0;
    bool zpressed;
   
    bool signrun;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("z") == true)
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

            if (signrun == false)
            {
                StartCoroutine(signmes());

            }
          


        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {

        text = collision.gameObject.GetComponent<PlayerText>();
        player = collision.gameObject.GetComponent<PlayerController>();
        if (zpressed == true)
        {

            if (signrun == false)
            {
                StartCoroutine(signmes());

            }



        }

    }

    public IEnumerator signmes()
    {

        //do stuff

        //wait for space to be pressed
        signrun = true;
        player.locked = true;
        StartCoroutine(text.print(" <i>You read the sign</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print(say, .7f, false));
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
        signrun = false;
        //do stuff once space is pressed

    }

  

}
