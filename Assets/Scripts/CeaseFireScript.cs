using UnityEngine;
using System.Collections;

public class CeaseFireScript : MonoBehaviour {

    //-Private Variables-//
    private MoveOnNavMesh meshAgentScript;
    //private UnitShooter shooterScript;
    public StartFireScript fireScript;
    //private IEnumerator shootCoroutine;

    //FUNCTION: Script sets references to other parts of the shooting unit character.
    //CALLED BY: Unity game engine
    void Start()
    {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
        //shooterScript = GetComponentInParent<UnitShooter>();
    }

    //FUNCTION: When player leaves collission, firing stops, and enemy starts moving at player again.
    //CALLED BY: Unity game engine when player leaves collider area.
    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
        fireScript.StopLocalCoroutine();
        
    }
}
