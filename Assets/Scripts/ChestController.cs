using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public PlayerText text;
    public bool opened;
    public bool bow;
    
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
            StartCoroutine(text.print("Press Z to open the chest.", 1.5f));
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "BowChest")
        {
            print("yes");
            if (Input.GetKeyDown("z") && !bow)
            {
                StartCoroutine(text.print("You have found a bow! Press Space to use it.", 1.5f));
                bow = true;
            }
            else if(Input.GetKeyDown("z") && opened)
            {
                StartCoroutine(text.print("There is nothing left in the chest.", 1.5f));
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "chest")
        {
            print("opened");
            opened = true;
        }
    }
}
