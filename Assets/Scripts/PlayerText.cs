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
   

   

    public IEnumerator print(string text, float time, bool clear = true)
    {
        Box.SetActive(true);
        Tmptxt.text = text;
        if (clear)
        {
            yield return new WaitForSeconds(time);
            Box.SetActive(false);
            Tmptxt.text = " ";
        }

    }

    }
