using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class door : MonoBehaviour
{
    public BoxCollider2D bx;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("g");
        if(collision.gameObject.name == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().haskey == true)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
