/*
This script works alongside UnitKamikaze to hit the player and cause damage.
Placed on a collider that is a child of the Unit and only hits the player (using layers).
 */

//Required Librariesusing UnityEngine;
using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
    
    //-Public Variables-//
    public float ColissionDamage = 50;

    //-Private Variables-//
    private Unit parentUnit;

    //FUNCTION: Sets up reference to parent object.
    //CALLED BY: Unity game engine
    void Start()
    {
        parentUnit = GetComponentInParent<Unit>();
    }

    //FUNCTION: Deals damage to player on hit. Deactivates ('kills') the Unit.
    //CALLED BY: Unity game engine on collission with player
    //INPUTS: Collider of the player that hit
    void OnTriggerEnter(Collider other) {
        UnitPlayer unitToDamage = other.GetComponent<UnitPlayer>();
        unitToDamage.TakeDamage(ColissionDamage);
        parentUnit.Kill();
	}
}
