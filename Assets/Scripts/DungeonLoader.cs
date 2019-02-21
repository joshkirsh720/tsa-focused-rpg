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
    public GameObject Box;

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
        Box.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetKeyDown("return"))
        {
            SceneManager.LoadScene("Dungeon");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Box.SetActive(false);
        Tmptxt.text = " ";
    }


}
