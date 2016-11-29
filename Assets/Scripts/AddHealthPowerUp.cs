/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

//NOT YET IMPLEMENTED.
public class AddHealthPowerUp : PowerUp
{
    
    public float HealthToAdd = 100;

    
    protected override void OnTriggerEnter(Collider other)
    {
        UnitPlayer unitToDamage = other.GetComponent<UnitPlayer>();
        unitToDamage.AddHealth(HealthToAdd);
        gameObject.SetActive(false);
    }
}
