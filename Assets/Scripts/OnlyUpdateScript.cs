/*
 
 
 */

using UnityEngine;
using System.Collections;
using System;

public class OnlyUpdateScript : MonoBehaviour {

    public static Action<KeyCode> UserMovementInput;
    public static Action GraphicalUpdates;
    public static Action PhysicsUpdates;
    public static Action PauseScripts;
    public static Action UnPauseScripts;

    public bool isPaused = false;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void Update () {

        GraphicalUpdates();
       

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            UserMovementInput(KeyCode.LeftArrow);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            UserMovementInput(KeyCode.RightArrow);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            UserMovementInput(KeyCode.UpArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (!isPaused)
            {
                print("Paused");
                PauseScripts();
                isPaused = true;
            }
            else
            {
                print("Unpaused");
                UnPauseScripts();
                isPaused = false;
            }
        }

        //Listens for Escape key, quits program when pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void FixedUpdate()
    {
        PhysicsUpdates();
    }



}
