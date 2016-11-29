/*
 This script centers camera on player with an offset. 
 Allows it to act like a child, but without rotation following.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class CameraUpdate : MonoBehaviour, IPausable {

    //-Public Variables-//
    public Transform playerRef;
    public const float CAMERA_OFFSET_Y = 15;
    public const float CAMERA_OFFSET_Z = 10;
    
    //FUNCTION: Subscribes self to all necessary actions in UpdateScript
    //CALLED BY: Unity game engine
    void Start ()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
    }

    //FUNCTION: Moves camera to look at player, based on offset values and player position
    //CALLED BY: UpdateScript.GraphicalUpdates action
    void positionCamera ()
    {
        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + CAMERA_OFFSET_Y, playerRef.position.z - CAMERA_OFFSET_Z);
	}

    //FUNCTION: Stops camera tracking the player.
    //CALLED BY: UpdateScript.OnPause action
    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= positionCamera;
    }

    //FUNCTION: Starts tracking again
    //CALLED BY: UpdateScript.OnUnPause action.
    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
    }
}
