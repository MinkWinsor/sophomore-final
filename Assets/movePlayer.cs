using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public float speed = 5;
    public float rotateSpeed = 20;
    public float dragFactor = 0.5f;
    public float gravity = 5;

    private Vector3 force;
    private CharacterController myCC;

	// Use this for initialization
	void Start () {
        force.y = -gravity;
        myCC = GetComponent<CharacterController>();
        StartCoroutine(moveScript());
        OnlyUpdateScript.UserMovementInput += rotatePlayerHandler;
        OnlyUpdateScript.UserMovementInput += addForceHandler;
        OnlyUpdateScript.PhysicsUpdates += movePlayerHandler;
	}

    IEnumerator moveScript()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(0.1f);

            print("Current Vector: " + force);
            if (force.x > 0)
                force.x -= force.x * dragFactor;
            if (force.z > 0)
                force.z -= force.z * dragFactor;
            if (force.x < 0)
                force.x -= force.x * dragFactor;
            if (force.z < 0)
                force.z -= force.z * dragFactor;

            
        }


    }
	
    void addForceHandler(KeyCode code)
    {

        if (code == KeyCode.UpArrow)
        {
            force += transform.forward * Time.deltaTime;
        }
    }

    void rotatePlayerHandler(KeyCode code)
    {
        if (code == KeyCode.RightArrow)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (code == KeyCode.LeftArrow)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }

    void movePlayerHandler()
    {
        myCC.Move(force * Time.deltaTime * speed);
    }

	
}
