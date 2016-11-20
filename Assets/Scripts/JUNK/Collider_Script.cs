using UnityEngine;
using System.Collections;

public class Collider_Script : MonoBehaviour {

    public Transform targetPosition;

	// Use this for initialization
	void Start () {
        //var targetPosition = targetTransform.position;
        //targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
	

    public void lookAt(Vector3 newTarget)
    {
        transform.LookAt(newTarget);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
