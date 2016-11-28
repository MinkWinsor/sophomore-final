/*
 
 */

 //Required Libraries
using UnityEngine;
using System.Collections;

public class CrashCollider : MonoBehaviour {
    
    //-Public Variables-//
    public float ColissionDamage = 100;
    
    //-Private Variables-//
    private movePlayer moveScript;
    private UnitPlayer playerScript;

    //FUNCTION:
    //CALLED BY:
    void Start () {
        //Scripts are found in parent player object.
        moveScript = GetComponentInParent<movePlayer>();
        playerScript = GetComponentInParent<UnitPlayer>();
    }

    //FUNCTION:
    //CALLED BY:
    void OnTriggerEnter () {
        //Player takes damage equal to ColissionDamage variable.
        playerScript.TakeDamage(ColissionDamage);
            
        //Move script runs a crash coroutine, slowing the player.
        StartCoroutine(moveScript.Crash());
	}
    
}
