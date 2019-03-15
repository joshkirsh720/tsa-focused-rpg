using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mole : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerText text;
    public string say;
    public BoxCollider2D bx;
    public PlayerController player;
    public Playerbadges pb;
    private int introlevel = 0;
    bool zpressed;
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
        if (zpressed == true)
        {

                StartCoroutine(intro0());

        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {

        text = collision.gameObject.GetComponent<PlayerText>();
        player = collision.gameObject.GetComponent<PlayerController>();
        pb = collision.gameObject.GetComponent<Playerbadges>();
        if (zpressed == true)
        {

            StartCoroutine(intro0());

        }
    }

    public IEnumerator intro0()
    {

        //do stuff

        //wait for space to be pressed
        player.locked = true;
        StartCoroutine(text.print(" <i>You talk to the mole</i>", .7f, false, false));
        yield return new WaitForSeconds(.5f);
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("You have unlocked " + Playerbadges.amountbadges/3 + " out of 2 badges", .7f, false));
        yield return new WaitForSeconds(.5f);
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        if (Playerbadges.amountbadges/3 == 2)
        {
            StartCoroutine(text.print("Wow. That's all of them", .7f, false));
            yield return new WaitForSeconds(.5f);
            while (Input.GetKeyDown("z") == false)
            {
                yield return null;

            }
            StartCoroutine(text.print("You should go to the hidden door in the dungeon", .5f, false));
            while (Input.GetKeyDown("z") == false)
            {
                yield return null;

            }
        }
        StartCoroutine(text.print("", .0f));
        player.locked = false;
        //do stuff once space is pressed
        introlevel = 1;
    }


}
