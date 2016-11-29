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
    
    //FUNCTION:
    //CALLED BY:
    void Start ()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
    }

    //FUNCTION:
    //CALLED BY:
    void positionCamera ()
    {
        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + CAMERA_OFFSET_Y, playerRef.position.z - CAMERA_OFFSET_Z);
	}

    //FUNCTION:
    //CALLED BY:
    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= positionCamera;
    }

    //FUNCTION:
    //CALLED BY:
    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
    }
}
