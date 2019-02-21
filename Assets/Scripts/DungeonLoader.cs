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
        Box.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("Dungeon");
    }

    private void OnTriggerStay2D(Collider2D col)
    {

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "rockbadge" || col.gameObject.name == "waterbadge")
        {
            Box.SetActive(true);
            Tmptxt.text = "Unlocked Badge!";
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Box.SetActive(false);
        Tmptxt.text = " ";
    }


}
