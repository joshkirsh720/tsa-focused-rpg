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
        StartCoroutine(text.print(" <i>The monster notices you</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Finally, my creator, you have arrived", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("My guard was supposed to take care of you", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Soon, I will be able to take over the world", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I'll make more like me", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("This couldn't have happened without you", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("You tried to play god and ended up creating a devil", .7f, false));
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
        StartCoroutine(text.print("Minions finish him off", .7f, false));
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
