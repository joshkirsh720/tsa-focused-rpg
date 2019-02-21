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
        SceneManager.LoadScene("Dungeon");
    }

  
}
