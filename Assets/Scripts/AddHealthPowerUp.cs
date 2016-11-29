/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class AddHealthPowerUp : PowerUp
{
    
    public float HealthToAdd = 100;

    
    protected override void OnTriggerEnter(Collider _other)
    {
        UnitPlayer unitToHeal = _other.GetComponent<UnitPlayer>();
        unitToHeal.AddHealth(HealthToAdd);
        gameObject.SetActive(false);
    }
}
