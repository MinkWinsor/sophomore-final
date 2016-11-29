/*
 This script is placed on a collider that is a child of the player or another unit,
 damages unit if collider hits something. (Usually a wall)
 */

 //Required Libraries
using UnityEngine;
using System.Collections;

public class CrashCollider : MonoBehaviour {
    
    //-Public Variables-//
    public float ColissionDamage = 100; //Changeable in inspector.
    
    //-Private Variables-//
    private MovePlayer moveScript;
    private UnitPlayer playerScript;

    //FUNCTION: Grabs the player script and player movement script.
    //CALLED BY: Unity game engine
    void Start () {
        //Scripts are found in parent player object.
        moveScript = GetComponentInParent<MovePlayer>();
        playerScript = GetComponentInParent<UnitPlayer>();
    }

    //FUNCTION: Is used when collider hits something. In our game, it is the player's collider hitting a wall.
    //CALLED BY: Unity game engine, on collission.
    void OnTriggerEnter () {
        //Player takes damage equal to ColissionDamage variable.
        playerScript.TakeDamage(ColissionDamage);
            
        //Move script runs a crash coroutine, slowing the player.
        StartCoroutine(moveScript.Crash());
	}
    
}
