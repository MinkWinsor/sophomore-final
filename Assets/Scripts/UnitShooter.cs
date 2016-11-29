using UnityEngine;
using System.Collections;

public class UnitShooter : Unit, IFiring {

    public float FireRate = 1;
    public bool CanShoot = true;
    public BulletRecycler myBulletRecycler;


    private MoveOnNavMesh meshAgentScript;

    //FUNCTION:
    //CALLED BY: Unity game engine
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

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public IEnumerator Fire(Transform target)
    {
        while (CanShoot)
        { 
            yield return new WaitForSeconds(FireRate);
            myBulletRecycler.FireBullet(this.transform.position, target.position);
        }
        
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public float HitTarget(float damageDone)
    {
        return 0;
    }
}
