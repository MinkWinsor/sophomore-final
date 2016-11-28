/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;

public class ProximityColission : MonoBehaviour {

    private MoveOnNavMesh meshAgentScript;
    private UnitShooter shooterScript;
    private IEnumerator shootCoroutine;

    // Use this for initialization
    void Start () {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
        shooterScript = GetComponentInParent<UnitShooter>();
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void OnTriggerEnter (Collider other) {
        meshAgentScript.StopMoving();
        
        shootCoroutine = shooterScript.Fire(other.transform.position);
        StartCoroutine(shootCoroutine);
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
        StopCoroutine(shootCoroutine);
    }
}
