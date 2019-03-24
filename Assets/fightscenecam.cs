﻿using System.Collections;
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
    public bool f = true;
   
    void Start()
    {
        EnemyController.start = false;
        if (f)
        {
            StartCoroutine(fight());
        }
        else
        {
            StartCoroutine(boss());
        }
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
        StartCoroutine(text.print(" <i>You encounter a guard</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
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
    public IEnumerator boss()
    {

        //do stuff

        //wait for space to be pressed
        intro0run = true;
        player.locked = true;
        StartCoroutine(text.print(" <i>The monster notices you </i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Minions. They are so weak", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I'll kill you myself", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;


        }
        StartCoroutine(text.print("Your puny punches and arrows don't hurt me", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I'm ALREADY DEAD", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I will take over the world all thanks to you", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Don't you realize, Science only leads to doom", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("How lazy can you humans get.... Pathetic", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("I'm doing you a favor by cleansing this planet", .7f, false));
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
