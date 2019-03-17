using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D Box;
    public string scene;
    public int loc;
    public PlayerController pc;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerController.lastloc = loc;
            SceneManager.LoadScene(scene);
        }

    }
}
