using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightscenecam : MonoBehaviour
{
    public PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    private int introlevel = 0;
    bool zpressed;
    public EnemyController ec;
    bool intro0run;
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
        intro0run = true;
        player.locked = true;
        StartCoroutine(text.print(" <i>You encounter a gaurd</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Get ready to fight", .7f, false));
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
        EnemyController.start = true;
        print("start");
        //do stuff once space is pressed

    }

   

}
