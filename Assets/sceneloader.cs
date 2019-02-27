using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D box;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene("Start");
    }
}
