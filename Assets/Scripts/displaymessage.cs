using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displaymessage : MonoBehaviour
{
public string message;
public BoxCollider2D bx;
int x = 0;
    // Start is called before the first frame update
    private void Update()
    {
        print("f");
    }
    void OnCollisionEnter(Collision collision)
    {
        print("i");
        if (collision.gameObject.name == "Player")
        {

            if (x == 0)
            {
                print(message);
            }
            else
            {
                print("you heard me");
            }

        }
    }
}
