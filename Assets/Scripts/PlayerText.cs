using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Tmptxt;
    public GameObject Box;
   

   

    public IEnumerator print(string text, float time, bool clear = true, bool typewriter = true)
    {
        Box.SetActive(true);
        if (typewriter)
        {
            int textf = text.Length + 1;
            for (int x = 0; x < textf; x++)
            {
                string display = text.Substring(0, x);
                Tmptxt.text = display;
                yield return new WaitForSeconds(.065f);
            }
        }
        else
        {
            Tmptxt.text = text;
        }
        if (clear)
        {
            yield return new WaitForSeconds(time);
            Box.SetActive(false);
            Tmptxt.text = " ";
        }

    }

    }
