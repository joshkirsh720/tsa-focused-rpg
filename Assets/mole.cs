using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mole : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D bx;
    private PlayerText pt;
    private Playerbadges pb;
    private bool zpressed;
    private PlayerController pc;
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
    private void OnCollisionEnter2D(Collision2D col)
    {

        pt = col.gameObject.GetComponent<PlayerText>();
        pb = col.gameObject.GetComponent<Playerbadges>();
        pc = col.gameObject.GetComponent<PlayerController>();
        if (zpressed == true)
        {
            StartCoroutine(d());
        }
        print(zpressed);

    }
    private void OnCollisionStay2D(Collision2D col)
    {
        pt = col.gameObject.GetComponent<PlayerText>();
        pb = col.gameObject.GetComponent<Playerbadges>();
        if (zpressed == true)
        {
            StartCoroutine(d());
        }
    }
    public IEnumerator d()
    {
        pc.locked = true;
        pt.print("You have unlocked" + pb.amountbadges + " out of 2 badges", .1f, false);
        yield return new WaitForSeconds(.5f);
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        if(pb.amountbadges == 2)
        {
            pt.print("Wow. That's all of them", .1f, false);
            yield return new WaitForSeconds(.5f);
            while (Input.GetKeyDown("z") == false)
            {
                yield return null;

            }
            pt.print("You should go to the hidden door in the dungeon", .1f, false);
            yield return new WaitForSeconds(.5f);
            while (Input.GetKeyDown("z") == false)
            {
                yield return null;

            }
            pt.print("", .0f, true);
            pc.locked = false;
        }
    }
}
