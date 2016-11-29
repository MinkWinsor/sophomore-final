using UnityEngine;
using System.Collections;
using System;

public class CameraUpdate : MonoBehaviour, IPausable {

    //-Public Variables-//
    public Transform playerRef;
    public const float CAMERA_OFFSET_Y = 15;
    public const float CAMERA_OFFSET_Z = 10;
    
    void Start ()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
    }
	
	void positionCamera ()
    {
        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + CAMERA_OFFSET_Y, playerRef.position.z - CAMERA_OFFSET_Z);
	}

    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= positionCamera;
    }

    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += positionCamera;
    }
}
