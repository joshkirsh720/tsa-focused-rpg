using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapLevelController : MonoBehaviour
{
    public string sceneName;
    public Text text;
    public int level;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        text.text = "Press space to enter level " + level;
        anim.SetBool("isOpening", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Space))
        {
            
            StartCoroutine(Wait());
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = "";
        anim.SetBool("isOpening", false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
