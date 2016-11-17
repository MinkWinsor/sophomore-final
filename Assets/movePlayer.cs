using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public float speed = 5;
    public float rotateSpeed = 20;
    public float dragFactor = 0.5f;
    public float gravity = 5;


    private const float MAX_SPEED_FACTOR = 2;

    private float maxSpeed;
    private bool rotatedRecently;
    private Vector3 force;
    private CharacterController myCC;

	// Use this for initialization
	void Start () {
        force.y = -gravity;
        myCC = GetComponent<CharacterController>();
        //StartCoroutine(moveScript());
        OnlyUpdateScript.UserMovementInput += rotatePlayerHandler;
        OnlyUpdateScript.UserMovementInput += addForceHandler;
        OnlyUpdateScript.PhysicsUpdates += movePlayerHandler;
        maxSpeed = speed * MAX_SPEED_FACTOR;
	}

    IEnumerator moveScript()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(0.1f);

            if (!Input.GetKey(KeyCode.UpArrow))
            {
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


    }

    /*public float getRelativeSpeed()
    {
        return ((Mathf.Abs(force.x) + (Mathf.Abs(force.z))) / (speed * 2));
    }*/
	
    void addForceHandler(KeyCode code)
    {

        if (code == KeyCode.UpArrow)
        {
            force += transform.forward * Time.deltaTime;
        }


        //After force is added, force is limited to the maximum speed.
        if(force.x > maxSpeed)
        {
            force.x = maxSpeed;
        }
        if (force.z > maxSpeed)
        {
            force.z = maxSpeed;
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

        if (!Input.GetKey(KeyCode.UpArrow) || rotatedRecently)
        {
            if (force.x > 0)
                force.x -= force.x * dragFactor * Time.deltaTime;
            if (force.z > 0)
                force.z -= force.z * dragFactor * Time.deltaTime;
            if (force.x < 0)
                force.x -= force.x * dragFactor * Time.deltaTime;
            if (force.z < 0)
                force.z -= force.z * dragFactor * Time.deltaTime;
            rotatedRecently = false;
        }
    }

	public IEnumerator Crash()
    {
        for(int i = 0; i < 10; i++)
        {
            print("crashing");
            if (force.x > 0)
                force.x -= force.x * 0.75f;
            if (force.z > 0)
                force.z -= force.z * 0.75f;
            if (force.x < 0)
                force.x -= force.x * 0.75f;
            if (force.z < 0)
                force.z -= force.z * 0.75f;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
