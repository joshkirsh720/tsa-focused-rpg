﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class king : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    public Playerbadges pb;
    private int introlevel = 0;
    bool zpressed;
    bool molenotrun;
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
        pb = collision.gameObject.GetComponent<Playerbadges>();
        if (zpressed == true && molenotrun == false)
        {

            StartCoroutine(intro0());

        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {

        text = collision.gameObject.GetComponent<PlayerText>();
        player = collision.gameObject.GetComponent<PlayerController>();
        pb = collision.gameObject.GetComponent<Playerbadges>();
        if (zpressed == true && molenotrun == false)
        {

            StartCoroutine(intro0());

        }
    }

    public IEnumerator intro0()
    {

        //do stuff
        molenotrun = true;
        //wait for space to be pressed
        player.locked = true;
        StartCoroutine(text.print(" <i>You talk to the mole</i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("How did you defeat the creature", .7f, false));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
       
            StartCoroutine(text.print("Thats impossible", .7f, false));
            while (PlayerText.printdone == false)
            {
                yield return null;
            }
            while (Input.GetKeyDown("z") == false)
            {
                yield return null;

            }
            StartCoroutine(text.print("Your evil creation", .5f, false));
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
        molenotrun = false;
        //do stuff once space is pressed
        introlevel = 1;
    }
}
