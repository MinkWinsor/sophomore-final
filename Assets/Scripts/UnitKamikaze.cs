using UnityEngine;
using System.Collections;

public class UnitKamikaze : Unit {

    private MoveOnNavMesh meshAgentScript;

    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }
}
