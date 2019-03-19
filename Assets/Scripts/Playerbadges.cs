using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerbadges : MonoBehaviour
{

    public PlayerText text;
    public BoxCollider2D box;
    public static int amountbadges = 0;
    public class badge
    {
        public static List<badge> badges = new List<badge>();
        public bool unlocked;
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

    public static badge rockbadge = new badge("Rock Badge");
    public static badge waterbadge = new badge("Water Badge");
    List<badge> badges = new List<badge>();

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

       


    }


   public void OnCollisionEnter2D(Collision2D col)
    {
        for (int count = 0; count < badge.badges.Count; count++)
        {
            string currentbadge = badge.badges[count].returnname();
            if (col.gameObject.name == currentbadge)
            {
                if (badge.badges[count].unlocked == false)
                {

                    badge.badges[count].unlocked = true;
                    amountbadges++;
                    print(amountbadges);
                    StartCoroutine(text.print(badge.badges[count].name + " Unlocked!", .9f, true, true, TMPro.TextAlignmentOptions.Center));
                    StartCoroutine(text.print("Go to the hidden forest south to see your progress", 1.5f, true, true, TMPro.TextAlignmentOptions.Center));
                    print(amountbadges);
                }

               
            }




        }
      
    }

   
}
