/*
 
 
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class OnlyUpdateScript : MonoBehaviour {

    //-Public Variables-//
    //Actions are used by many scripts to allow updating on update, when user presses keys, etc.
    public static Action<KeyCode> UserMovementInput; //For moving the player.
    public static Action GraphicalUpdates; //For updating graphics that need updating every frame.
    public static Action PhysicsUpdates; //For objects that need to move on each physics update.
    public static Action PauseScripts; //For any code that should run when game is paused.
    public static Action UnPauseScripts; //Same as above, for code that runs when game is unpaused.
    public bool isPaused = false;



    //FUNCTION:
    //CALLED BY: The unity game engine with every frame update.
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
            Application.Quit();
        }
    }

    //FUNCTION:
    //CALLED BY: Unit engine with every physics update.
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
