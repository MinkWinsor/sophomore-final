using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

    public Transform playerRef;

    public const float CAMERA_OFFSET_Y = 15;
    public const float CAMERA_OFFSET_Z = 10;

    // Use this for initialization
    void Start () {
        OnlyUpdateScript.GraphicalUpdates += positionCamera;
	}
	
	// Update is called once per frame
	void positionCamera () {

        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + CAMERA_OFFSET_Y, playerRef.position.z - CAMERA_OFFSET_Z);

	}
}
