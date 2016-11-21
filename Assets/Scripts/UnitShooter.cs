using UnityEngine;
using System.Collections;

public class UnitShooter : Unit, IFiring {

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
    
    public void Fire()
    {

    }

    public float HitTarget(float damageDone)
    {
        return 0;
    }
}
