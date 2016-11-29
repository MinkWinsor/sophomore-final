/*
Works in conjunction with StartFireScript
Tells UnitShooter type of enemy to stop firing and moving once the player has gotten out of range.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class CeaseFireScript : MonoBehaviour {

    //-Private Variables-//
    private MoveOnNavMesh meshAgentScript;
    public StartFireScript fireScript;

    //FUNCTION: Script sets references to shooting unit character.
    //CALLED BY: Unity game engine
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    //FUNCTION: When player leaves collission, firing stops, and enemy starts moving at player again.
    //CALLED BY: Unity game engine when player leaves collider area.
    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
        fireScript.StopLocalCoroutine();
        
    }
}
