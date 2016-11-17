using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

    public Transform playerRef;

	// Use this for initialization
	void Start () {
        OnlyUpdateScript.GraphicalUpdates += positionCamera;
	}
	
	// Update is called once per frame
	void positionCamera () {

        transform.position = new Vector3(playerRef.position.x, playerRef.position.y + 15, playerRef.position.z - 10);

	}
}
