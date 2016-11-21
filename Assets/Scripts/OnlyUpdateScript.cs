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

        if (GraphicalUpdates != null)
            GraphicalUpdates();
       

        if (Input.GetKey(KeyCode.LeftArrow) && UserMovementInput != null)
        {
            UserMovementInput(KeyCode.LeftArrow);
        }
        if (Input.GetKey(KeyCode.RightArrow) && UserMovementInput != null)
        {
            UserMovementInput(KeyCode.RightArrow);
        }
        if (Input.GetKey(KeyCode.UpArrow) && UserMovementInput != null)
        {
            UserMovementInput(KeyCode.UpArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space) && PauseScripts != null)
        {
            
            if (!isPaused)
            {
                PauseScripts();
                isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                UnPauseScripts();
                isPaused = false;
                Time.timeScale = 1;
            }
        }

        //Listens for Escape key, quits program when pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneControl.QuitGame();
        }
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void FixedUpdate()
    {
        if(PhysicsUpdates != null)
            PhysicsUpdates();
    }

    void OnDestroy()
    {
        UserMovementInput = null;
        GraphicalUpdates = null;
        PhysicsUpdates = null;
        PauseScripts = null;
        UnPauseScripts = null;
}

}
