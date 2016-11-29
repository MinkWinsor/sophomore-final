/*
 UnitPlayer script, allows the player to take damage and add health.
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class UnitPlayer : Unit, IHealth {
    

    //FUNCTION: Implented from IHealth, reduces health amount of the player. Updates health bar.
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public override float TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);
        
        return health;
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public override float AddHealth(float _addedHealth)
    {
        base.AddHealth(_addedHealth);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);

        return (health);
    }

    //FUNCTION:
    //CALLED BY:
    public override void Kill()
    {
        SceneControl.ReloadCurrentScene();
    }
}
