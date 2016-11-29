/*
 Damaging power up. Hurts player on collission.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class TakeDamagePowerUp : PowerUp {

    //-Public Variables-//
    public float DamageAmount = 50;

    //FUNCTION: Hurts player that collides with it.
    //CALLED BY: Unity game engine when player collides with this object.
    //INPUTS: Collider that hit the object.
    protected override void OnTriggerEnter(Collider _other)
    {
        UnitPlayer unitToDamage = _other.GetComponent<UnitPlayer>();
        unitToDamage.TakeDamage(DamageAmount); //Damages player.
        gameObject.SetActive(false); //Deactivates
    }
}
