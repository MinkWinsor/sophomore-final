using UnityEngine;
using System.Collections;
using System;

public class CameraRotate : MonoBehaviour, IPausable {

    public Transform playerRef;

    public const float CAMERA_OFFSET_Y = 15;
    public const float CAMERA_OFFSET_Z = 10;

    // Use this for initialization
    void Start () {
        OnlyUpdateScript.GraphicalUpdates += positionCamera;
        OnlyUpdateScript.PauseScripts += OnPause;
        OnlyUpdateScript.UnPauseScripts += OnUnPause;
	}
	
	// Update is called once per frame
	void positionCamera () {

        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + CAMERA_OFFSET_Y, playerRef.position.z - CAMERA_OFFSET_Z);

	}

    public void OnPause()
    {
        OnlyUpdateScript.GraphicalUpdates -= positionCamera;
    }

    public void OnUnPause()
    {
        OnlyUpdateScript.GraphicalUpdates += positionCamera;
    }
}
