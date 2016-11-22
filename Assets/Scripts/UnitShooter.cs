using UnityEngine;
using System.Collections;

public class UnitShooter : Unit, IFiring {

    public float FireRate = 1;
    public bool CanShoot = true;
    public BulletRecycler myBulletRecycler;


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
    
    public IEnumerator Fire(Vector3 target)
    {
        while (CanShoot)
        { 
            yield return new WaitForSeconds(FireRate);
            print("UnitShooter Firing");
            myBulletRecycler.FireBullet(this.transform.position, target);
        }
        
    }

    public float HitTarget(float damageDone)
    {
        return 0;
    }
}
