using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public PlayerText text;
    public bool opened;
    public bool bow;
    public bool nothingrun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "chest")
        {
            if (col.gameObject.name == "BowChest")
            {

                if (Input.GetKeyDown("z") && !bow)
                {
                    StartCoroutine(foundbow());


                }
                if (Input.GetKeyDown("z") && opened && nothingrun == false)
                {
                    StartCoroutine(nothing());
                }
            }
            else
            {
                if (Input.GetKeyDown("z") && nothingrun == false)
                {
                    StartCoroutine(nothing());
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "chest")
        {
            if (col.gameObject.name == "BowChest")
            {

                if (Input.GetKeyDown("z") && !bow)
                {
                    StartCoroutine(foundbow());


                }
                if (Input.GetKeyDown("z") && opened && nothingrun == false)
                {
                    StartCoroutine(nothing());
                }
            }
            else
            {
                if (Input.GetKeyDown("z") && nothingrun == false)
                {
                    StartCoroutine(nothing());
                }
            }
        }
    }


    public IEnumerator foundbow()
    {
        bow = true;
        StartCoroutine(text.print("You found a bow! Press Space to use it", .7f,false,true,TMPro.TextAlignmentOptions.Center));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
     
        StartCoroutine(text.print("", .0f));
        opened = true;
    }
    public IEnumerator nothing()
    {
        nothingrun = true;
        bow = true;
        StartCoroutine(text.print("There is nothing in this chest :(", .7f, false, true, TMPro.TextAlignmentOptions.Center));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
       
        StartCoroutine(text.print("", .0f));
        nothingrun = false;
    }
}
