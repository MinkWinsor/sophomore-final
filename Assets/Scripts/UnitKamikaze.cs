/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class UnitKamikaze : Unit {

    private MoveOnNavMesh meshAgentScript;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }
}
