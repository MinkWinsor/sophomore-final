/*
 Abstract class for units. Mainly sets up health and damage functions. 
 Used on any unit, players and NPCs alike.
 */

using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

    //All Units have health, and max health.
    //Max health is for limiting overhealing, and displaying health bars.
    public float health = 1000;
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
        health -= _damage;
        if (health <= 0)
            Kill();
        return health;
	}

    //FUNCTION: Used to add health to unit. Won't go above maximum health.
    //CALLED BY: Any function wanting that adds health to a unit.
    //INPUTS: Amount of health to add.
    //OUTPUTS: New health amount after it's added.
    public virtual float AddHealth (float _addedHealth)
    {
        health += _addedHealth;
        if (health > healthMax)
            health = healthMax;
        return health;
    }
    

    //FUNCTION: Destroys game object.
    //CALLED BY: TakeDamage, or other functions that would kill the unit. This function should only be called by it's own class.
    protected void Kill()
    {
        Destroy(gameObject);
    }
}
