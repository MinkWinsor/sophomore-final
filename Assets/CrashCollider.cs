using UnityEngine;
using System.Collections;

public class CrashCollider : MonoBehaviour {

    private movePlayer moveScript;

	// Use this for initialization
	void Start () {
        moveScript = GetComponentInParent<movePlayer>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
        StartCoroutine(moveScript.Crash());
	}
}
