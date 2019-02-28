using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerbadges : MonoBehaviour
{

    public PlayerText text;
    public BoxCollider2D box;
    public class badge
    {
        public static List<badge> badges = new List<badge>();
        public bool unlocked = false;
        string name;
        public badge(string name)
        {
            this.name = name;
            badges.Add(this);

        }
        public List<badge> returnbadges()
        {
            return badges;
        }
        public string returnname()
        {
            return name;
        }
        public bool returnlock()
        {
            return unlocked;
        }

    }

    public badge rockbadge = new badge("rockbadge");
    public badge waterbadge = new badge("waterbadge");
    List<badge> badges = new List<badge>();
    public bool bow = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        badges = waterbadge.returnbadges();


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        for (int count = 0; count < badges.Count; count++)
        {
            string currentbadge = badges[count].returnname();
            if (col.gameObject.name == currentbadge)
            {
                if (badges[count].unlocked == false)
                {
                    badges[count].unlocked = true;
                    StartCoroutine(text.print("Badge Unlocked!", .7f));
                }
                else if (badges[count].unlocked == true)
                {
                    StartCoroutine(text.print("Badge Already Unlocked!", .7f));
                }

            }

        }
        if (col.gameObject.tag == "chest")
        {
            StartCoroutine(text.print("Press Z to open the chest.", 4.0f));
            bow = true;
        }
    }
}
