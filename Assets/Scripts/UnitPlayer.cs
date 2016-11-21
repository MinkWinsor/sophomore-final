﻿/*
 
 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UnitPlayer : Unit {

    

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public override float TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        healthBar.transform.localScale = new Vector3((health / healthMax), 1, 1);
        print(health);
        return health;
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public override float AddHealth(float _addedHealth)
    {
        return (base.AddHealth(_addedHealth));
    }
    
}
