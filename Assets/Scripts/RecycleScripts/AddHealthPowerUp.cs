/*
 Healing power up, causes health gain on collission.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class AddHealthPowerUp : PowerUp
{
    
    //-Public Variables-//
    public float HealthToAdd = 100;

    //FUNCTION: Heals player that collides with it.
    //CALLED BY: Unity game engine when player collides with this object.
    //INPUTS: Collider that hit the object.
    protected override void OnTriggerEnter(Collider _other)
    {
        UnitPlayer unitToHeal = _other.GetComponent<UnitPlayer>();
        unitToHeal.AddHealth(HealthToAdd); //Adds health
        gameObject.SetActive(false); //Deactivates
    }
}
