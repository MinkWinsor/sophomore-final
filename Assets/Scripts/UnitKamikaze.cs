/*
 Function that controls the kamikaze unit. Mainly stops the navMesh when object is deactivated.
 Works alongside EnemyCollider script.
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class UnitKamikaze : Unit {

    //-Private Variables-//
    private MoveOnNavMesh meshAgentScript;

    //FUNCTION: Sets up references.
    //CALLED BY: Unity game engine.
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    //FUNCTION: Deactivates game object and stops the NavMeshAgent
    //CALLED BY: Collider when it hits the player.
    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }
}
