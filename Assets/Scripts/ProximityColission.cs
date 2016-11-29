/*
 This script is used by the UnitShooter type of enemy, to determine if the player is within firing range.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class ProximityColission : MonoBehaviour {

    //-Private Variables-//
    private MoveOnNavMesh meshAgentScript;
    private UnitShooter shooterScript;
    private IEnumerator shootCoroutine;

    //FUNCTION: Script sets references to other parts of the shooting unit character.
    //CALLED BY: Unity game engine
    void Start () {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
        shooterScript = GetComponentInParent<UnitShooter>();
    }

    //FUNCTION: When the collider hits, it starts the unit shooting at what it hit.
    //CALLED BY: Unity game engine when unit hits the player.
    //INPUTS: Object that collided with it.
    void OnTriggerEnter (Collider other) {
        meshAgentScript.StopMoving();
        
        shootCoroutine = shooterScript.Fire(other.transform.position);
        StartCoroutine(shootCoroutine);
    }

    //FUNCTION: When player leaves collission, firing stops, and enemy starts moving at player again.
    //CALLED BY: Unity game engine when player leaves collider area.
    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
        StopCoroutine(shootCoroutine);
    }
}
