/*
 Abstract class for units. Mainly sets up health and damage functions. 
 Used on any unit, players and NPCs alike.
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour {

    //-Public Variables-//
    //All Units have health, and max health.
    //Max health is for limiting overhealing, and displaying health bars.
    public float health = 1000;
    public Image healthBar;
    protected float healthMax;


    
    //FUNCTION: Start function, initializes variables.
    //CALLED BY: Unity game engine.
    void Start()
    {
        //As units are expected to start at full health, maxHealth is initialized to health.
        healthMax = health;
    }

    //FUNCTION: Used to subtract health when unit takes damage. Kills unit if health hits 0.
    //CALLED BY: Any function wanting to deal damage to the unit.
    //INPUTS: Amount of damage to deal.
    //OUTPUTS: Health after damage is dealt.
	public virtual float TakeDamage (float _damage)
    {
        health -= _damage; //Damage dealt.
        if (health <= 0) //Kill function called if health has dropped below 0.
            Kill();
        return health;
	}

    //FUNCTION: Used to add health to unit. Won't go above maximum health.
    //CALLED BY: Any function wanting that adds health to a unit.
    //INPUTS: Amount of health to add.
    //OUTPUTS: New health amount after it's added.
    public virtual float AddHealth (float _addedHealth)
    {
        health += _addedHealth; //Health added.
        if (health > healthMax) //Restricted to maxHealth.
            health = healthMax;
        return health;
    }
    

    //FUNCTION: Destroys (Deactivates) game object. Doesn't actually destroy it, because most units can be recycled and such.
    //CALLED BY: TakeDamage, or other functions that would kill the unit. This function should only be called by it's own class.
    public virtual void Kill()
    {
        gameObject.SetActive(false);
    }
    
}
