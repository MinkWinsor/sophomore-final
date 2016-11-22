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
	
	void OnTriggerEnter (Collider other) {
        meshAgentScript.StopMoving();
        
        shootCoroutine = shooterScript.Fire(other.transform.position);
        StartCoroutine(shootCoroutine);
    }

    void OnTriggerExit()
    {
        meshAgentScript.StartMoving();
        StopCoroutine(shootCoroutine);
    }
}
