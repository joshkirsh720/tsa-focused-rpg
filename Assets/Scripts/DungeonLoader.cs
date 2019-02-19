using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DungeonLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Tmptxt;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Tmptxt.text = "Press enter to enter the dungeon.";       
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Dungeon");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tmptxt.text = "";
    }
}
