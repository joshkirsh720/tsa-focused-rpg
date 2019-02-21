using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerbadges : MonoBehaviour
{

  
    public class badge
    {
        public List<badge> badges = new List<badge>();
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

    }

    public badge rockbadge = new badge("rockbadge");
    public badge waterbadge = new badge("waterbadge");
    List<badge> badges = new List<badge>();


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        badges = rockbadge.returnbadges();

    }
     void OnCollisionEnter(Collision col)
    {
         for (int count = 0; count < badges.Count; count++)
         {
             string currentbadge = badges[count].returnname();
             if (col.gameObject.name == currentbadge )
             {
                 badges[count].unlocked = true;
                 print("UNLOCKED BADGE");
             }

         }

      
        print("fuck");
    }
}
