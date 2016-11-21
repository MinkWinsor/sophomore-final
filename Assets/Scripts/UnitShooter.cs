using UnityEngine;
using System.Collections;

public class UnitShooter : Unit, IFiring {

    public float FireRate = 1;
    public bool CanShoot = false;


    private MoveOnNavMesh meshAgentScript;

    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
        StartCoroutine(Fire());
    }

    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }
    
    public IEnumerator Fire(Vector3 target)
    {
        while (CanShoot)
        {
            yield return new WaitForSeconds(FireRate);
            print("UnitShooter Firing");
        }
        
    }

    public float HitTarget(float damageDone)
    {
        return 0;
    }
}
