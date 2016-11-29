/*
 UnitPlayer script, allows the player to take damage and add health.
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class UnitPlayer : Unit, IHealth {
    

    //FUNCTION: Implented from IHealth, reduces health amount of the player. Updates health bar.
    //CALLED BY: Anything that wants to deal damage to the player.
    //INPUTS: Amount of damage to deal
    //OUTPUTS: Health afterwards
    public override float TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);
        
        return health;
    }

    //FUNCTION: Implemented from IHealth, adds health to player, updates health bar.
    //CALLED BY: Anything that wants to heal player.
    //INPUTS: Amount to add
    //OUTPUTS: Health afterwards.
    public override float AddHealth(float _addedHealth)
    {
        base.AddHealth(_addedHealth);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);

        return (health);
    }

    //FUNCTION: Reloads level
    //CALLED BY: TakeDamage script, or anything that would kill player.
    public override void Kill()
    {
        LevelLoader.ReloadCurrentScene();
    }
}
