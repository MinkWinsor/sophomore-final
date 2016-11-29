/*
UnitShooter. A unit that can fire at the player. 
Moves to a certain distance, and will fire at player until player gets a certain distance away.
UnitShooter units use StartFireScript, CeaseFireScript, and MoveOnNavMesh
 */

//Required Librariesusing UnityEngine;
using UnityEngine;
using System.Collections;

public class UnitShooter : Unit, IFiring {

    //-Public Variables-//
    public float FireRate = 1;
    public bool CanShoot = true;
    public BulletRecycler myBulletRecycler;

    //-Private Variables-//
    private MoveOnNavMesh meshAgentScript;

    //FUNCTION: Sets up reference to NavMeshAgent
    //CALLED BY: Unity game engine
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
    }

    //FUNCTION: Deactivate unit and stop navigation
    //CALLED BY: Colliders when unit hits player.
    public override void Kill()
    {
        meshAgentScript.StopMoving();
        gameObject.SetActive(false);
    }

    //FUNCTION: Fires a bullet at a target on a time-based interval
    //CALLED BY: Colliders that sense when a player is near enough.
    //INPUTS: Target to be shot at, as a reference to a transform.
    //OUTPUTS: IEnumerator reference to itself.
    public IEnumerator Fire(Transform target)
    {
        while (CanShoot) //Can be stopped with this, but is usually stopped by StopCoroutine()
        { 
            yield return new WaitForSeconds(FireRate);
            myBulletRecycler.FireBullet(this.transform.position, target.position);
        }
    }
    
}
