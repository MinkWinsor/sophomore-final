using UnityEngine;
using System.Collections;

public class ProximityColission : MonoBehaviour {

    private MoveOnNavMesh meshAgentScript;
    private UnitShooter shooterScript;

    // Use this for initialization
    void Start () {
        meshAgentScript = GetComponentInParent<MoveOnNavMesh>();
        shooterScript = GetComponentInParent<UnitShooter>();
    }
	
	void OnTriggerEnter (Collider other) {
        meshAgentScript.StopMoving();
        shooterScript.CanShoot = true;
        StartCoroutine(shooterScript.Fire(other.transform.position));
	}

    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
    }
}
