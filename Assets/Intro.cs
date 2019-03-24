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
        StartCoroutine(text.print("You have made a grave mistake.", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("In your attempt to animate the dead, you've released a beast upon the land", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft)); 
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("The evil deformed creation has been ravaging the poor people of the lands", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("It was last seen running into the caves up north", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("You need to stop it before it takes over the world", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }

        StartCoroutine(text.print("Sometimes dead is better", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }
        StartCoroutine(text.print("I wish you good luck", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
        while (PlayerText.printdone == false)
        {
            yield return null;
        }
        while (Input.GetKeyDown("z") == false)
        {
            yield return null;
        }
        StartCoroutine(text.print("You will need it", 0.7f, false, true, TMPro.TextAlignmentOptions.TopLeft));
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
