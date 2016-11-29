/*
 Movement controlling script for the player.
 All functions are called by actions in the UpdateScript
 Uses interfaces to move the player, and pause the player.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class MovePlayer : MonoBehaviour, IMoving, IPausable {

    //-Public Variables-//
    public float speed = 5;
    public float rotateSpeed = 20;
    public float dragFactor = 0.5f;
    public float gravity = 5;

    //-Private Variables-//
    private const float MAX_SPEED_FACTOR = 2;
    private float maxSpeed;
    private bool rotatedRecently = false;
    private Vector3 force;
    private CharacterController myCC;

    //FUNCTION: Start function, all actions subscribed to, gravity added to keep player grounded, etc.
    //CALLED BY: Unity game engine
    void Start () {
        force.y = -gravity;
        myCC = GetComponent<CharacterController>();
        UpdateScript.UserMovementInput += rotateHandler;
        UpdateScript.UserMovementInput += addForceHandler;
        UpdateScript.PhysicsUpdates += moveHandler;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
        maxSpeed = speed * MAX_SPEED_FACTOR;
	}

    //FUNCTION: Adds forward thrust to the player when user input is detected.
    //CALLED BY: UpdateScript.UserMovementInput when keys are pressed.
    //INPUTS: KeyCode of key that user hit.
    void addForceHandler(KeyCode code)
    {
        //Force added.
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

    //FUNCTION: Rotates the player when rotate keys are hit.
    //CALLED BY: UpdateScript.UserMovementInput when keys are pressed.
    //INPUTS: KeyCode of key that user hit.
    public void rotateHandler(KeyCode code)
    {
        //Rotation in appropriate direction.
        if (code == KeyCode.RightArrow)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            rotatedRecently = true;
        }
        if (code == KeyCode.LeftArrow)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            rotatedRecently = true;
        }
        
    }

    //FUNCTION: Move the player.
    //CALLED BY: UpdateScript.PhysicsUpdates every physics update.
    public void moveHandler()
    {
        //Player moves!
        myCC.Move(force * Time.deltaTime * speed);

        //Player drag occurs whenever player is turning or isn't moving.
        if (!Input.GetKey(KeyCode.UpArrow) || rotatedRecently)
        {
            if (force.x > 0)
                force.x -= force.x * dragFactor * Time.deltaTime; //Questionable whether I need Time.deltatime here.
            if (force.z > 0)
                force.z -= force.z * dragFactor * Time.deltaTime;
            if (force.x < 0)
                force.x -= force.x * dragFactor * Time.deltaTime;
            if (force.z < 0)
                force.z -= force.z * dragFactor * Time.deltaTime;
            rotatedRecently = false;
        }
    }


    //FUNCTION: Coroutine that slows the player over a short time.
    //CALLED BY: Child object with a collider and the CrashCollider script.
    //OUTPUTS: An IEnumerator reference.
    public IEnumerator Crash()
    {
        //We use a coroutine to stop too suddenly.
        //Causes major drag on the player.
        for(int i = 0; i < 10; i++)
        {
            if (force.x > 0)
                force.x -= force.x * dragFactor;
            if (force.z > 0)
                force.z -= force.z * dragFactor;
            if (force.x < 0)
                force.x -= force.x * dragFactor;
            if (force.z < 0)
                force.z -= force.z * dragFactor;
            yield return new WaitForSeconds(0.1f);
        }
        
    }


    //FUNCTION: Unsubscribes from the actions when game is paused, prevents this script running while paused.
    //CALLED BY: UpdateScript.PauseScripts when game is paused.
    public void OnPause()
    {
        UpdateScript.UserMovementInput -= rotateHandler;
        UpdateScript.UserMovementInput -= addForceHandler;
        UpdateScript.PhysicsUpdates -= moveHandler;
    }

    //FUNCTION: Subscribes to actions when game is unpaused.
    //CALLED BY: UpdateScript.UnPauseScripts when game is unpaused.
    public void OnUnPause()
    {
        UpdateScript.UserMovementInput += rotateHandler;
        UpdateScript.UserMovementInput += addForceHandler;
        UpdateScript.PhysicsUpdates += moveHandler;
    }
}
