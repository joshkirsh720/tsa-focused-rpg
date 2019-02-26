using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badge : MonoBehaviour
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
