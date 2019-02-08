using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
    public int damage;
    public int knockback;
    public int range;

    private Vector3 offset;
    
    public override void PrimaryAction()
    {
        //use signs of the values to determine the direction the player is facing and attack in that direction
        offset = new Vector3(controller.xSign * (.5f * range), controller.ySign * (.5f * range));

        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(user.transform.position + offset, new Vector2(.5f * range, .5f * range), 0);
        for (int i = 0; i < enemiesHit.Length; i++)
        {
            if(enemiesHit[i].gameObject.tag == "Enemy")
            {
                //take damage
                //enemiesHit[i].gameObject.GetComponent<EnemyController>.TakeDamage(damage);
            }
        }        
    }

    public override void SecondaryAction()
    {
        
    }
}
