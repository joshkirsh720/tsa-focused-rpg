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
    public Playerbadges.badge rockbadge;

    void Start()
    {

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
        if(col.gameObject.tag == "badge")
        {
            Box.SetActive(true);
            Tmptxt.text = "Badge Unlocked!";
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Box.SetActive(false);
        Tmptxt.text = " ";
    }


}
