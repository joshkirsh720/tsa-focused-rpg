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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
      
            text = collision.gameObject.GetComponent<PlayerText>();
            player = collision.gameObject.GetComponent<PlayerController>();
            StartCoroutine(wait());
        
    }

    public IEnumerator wait()
    {

        //do stuff

        //wait for space to be pressed
        player.locked = true;

        StartCoroutine(text.print("Help, Robbers took my TSA Badge. They took it to the caves up north", .7f, false));
        yield return new WaitForSeconds(.5f);
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("Will you help me get it back", .7f, false));
        yield return new WaitForSeconds(.5f);
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        StartCoroutine(text.print("", .0f));
        player.locked = false;
        //do stuff once space is pressed

    }

}
