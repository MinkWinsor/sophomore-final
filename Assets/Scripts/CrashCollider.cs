using UnityEngine;
using System.Collections;

public class CrashCollider : MonoBehaviour {

    public float ColissionDamage = 100;
    
    private movePlayer moveScript;
    private UnitPlayer playerScript;

	// Use this for initialization
	void Start () {
        //Scripts are found in parent player object.
        moveScript = GetComponentInParent<movePlayer>();
        playerScript = GetComponentInParent<UnitPlayer>();
    }
	
	void OnTriggerEnter () {
        //Player takes damage equal to ColissionDamage variable.
        playerScript.TakeDamage(ColissionDamage);
            
        //Move script runs a crash coroutine, slowing the player.
        StartCoroutine(moveScript.Crash());
	}
    
}
