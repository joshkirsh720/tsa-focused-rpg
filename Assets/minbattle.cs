using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minbattle : MonoBehaviour
{
    public PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    private int introlevel = 0;
    bool zpressed;
    public EnemyController ec;
    bool intro0run;
    public Rigidbody2D boss;
    public Animator bossanim;
    void Start()
    {
        StartCoroutine(fight());
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


    public IEnumerator fight()
    {

        //do stuff

        //wait for space to be pressed
        EnemyController.start = false;
        intro0run = true;
        player.locked = true;
        StartCoroutine(text.print(" <i>Evil King Treant Notices you</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Ah. King Vlad must have sent you", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("My guard was supposed to take care of you... Disapointing", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Soon I will have all the power of the TSA Badge", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I'll be unstoppabel", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("HAHAHHAHAHAHHAHAHAHAHHA", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("HAHAHHAHAHAHHAHAHAHAHHA", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("HAHAHHAHAHAHHAHAHAHAHHA", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Minions finish him/her/ off", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I may be evil, but I don't assume", .7f, false));
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
        boss.velocity = new Vector2(0, .25f);
        bossanim.SetBool("walkback", true);
        EnemyController.start = true;
        print("start");
        //do stuff once space is pressed

    }


}
