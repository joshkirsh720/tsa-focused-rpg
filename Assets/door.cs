using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class door : MonoBehaviour
{
    public BoxCollider2D bx;
    public string scene;
    public PlayerText text;
    public bool f = true;
    //lol
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator exit()
    {
        StartCoroutine(text.print(" <i>You will leave the dungeon </i>", .7f, false, false, TMPro.TextAlignmentOptions.Center));
        print("kil");
        while (PlayerText.printdone == false)
        {
            yield return null;
        }

        while (Input.GetKeyDown("z") == false)
        {
            yield return null;

        }
        SceneManager.LoadScene(scene);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("g");
        if (f)
        {
            if (collision.gameObject.name == "Boss")
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().haskey == true)
            {
                if (f)
                {
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    StartCoroutine(exit());
                }
            }
        }
    }
}
