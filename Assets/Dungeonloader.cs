using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dungeonloader : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D Box;
    public string scene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene(scene);
    }
}
