using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public abstract class Item : ScriptableObject
{
    //rn only the player can use items, gonna change that later
    public GameObject user;
    public PlayerController controller;

    public new string name;
    public string description;
    public int value;
    public double timeBetweenUses, cooldown;

    public Sprite artwork;
    public Animator animator;

    public void Awake()
    {
        user = GameObject.FindGameObjectWithTag("Player");

        //bc it returns null if it doesn't find the script, you can use ?? to have an enemy just attack towards the player
        controller = user.GetComponent<PlayerController>();
    }


    public string PickupText()
    {
        return name + ": " + description;
    }

    public abstract void PrimaryAction();
    public abstract void SecondaryAction();

}
