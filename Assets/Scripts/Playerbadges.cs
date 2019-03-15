﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerbadges : MonoBehaviour
{

    public PlayerText text;
    public BoxCollider2D box;
    public int amountbadges = 0;
    public class badge
    {
        public static List<badge> badges = new List<badge>();
        public bool unlocked = false;
        public string name;
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

    public badge rockbadge = new badge("Rock Badge");
    public badge waterbadge = new badge("Water Badge");
    List<badge> badges = new List<badge>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        badges = waterbadge.returnbadges();


    }


   public void OnCollisionEnter2D(Collision2D col)
    {
        for (int count = 0; count < badges.Count; count++)
        {
            string currentbadge = badges[count].returnname();
            if (col.gameObject.name == currentbadge)
            {
                if (badges[count].unlocked == false)
                {
                    badges[count].unlocked = true;
                    StartCoroutine(text.print(badges[count].name + " Unlocked!", .9f));
                    amountbadges++;
                }
                else if (badges[count].unlocked == true)
                {
                    StartCoroutine(text.print("Badge Already Unlocked!", .7f));
                }

            }

        }
      
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(Input.GetKeyDown("z"))
        {

        }
    }
}
