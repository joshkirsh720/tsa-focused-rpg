using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerText text;
    bool zpressed;
    bool introrun;
    public GameObject vlad;
    

    void Start()
    {
        introrun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(introrun)
        {
            StartCoroutine(story());
            introrun = false;
        }

        if (Input.GetKey("z") == true)
        {
            zpressed = true;

        }
        else
        {
            zpressed = false;
        }

    }

    public IEnumerator story()
    {
        vlad.SetActive(true);
        StartCoroutine(text.print("You are a close friend of the king of the land.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("Your king has used a secret magical object for ages to maintain his rule over the kingdom.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft)); 
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("However, The evil tree ruler has somehow managed to get into the castle and steal the object.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("Now, he will gain the immense power from the badge and will finally able to take over the world.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("Your mission is to stop this by stealing the badge back from the king's rival.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("The tree king was last spotted fleeing into the caves up north", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }
        StartCoroutine(text.print("Good luck", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        SceneManager.LoadScene("Start");
    }


}
