/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class UnitKamikaze : Unit {

    private MoveOnNavMesh meshAgentScript;

    //FUNCTION:
    //CALLED BY:
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    //FUNCTION:
    //CALLED BY:
    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }
}
