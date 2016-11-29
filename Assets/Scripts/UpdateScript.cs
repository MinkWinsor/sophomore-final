/*
 This script is the only script that uses Update and FixedUpdate.
 All other scripts that need to update on a per-frame basis use actions in this script.
 
 */

 //Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class UpdateScript : MonoBehaviour, IPausable {

    //-Public Variables-//
    //Actions are used by many scripts to allow updating on update, when user presses keys, etc.
    public static Action<KeyCode> UserMovementInput; //For moving the player.
    public static Action GraphicalUpdates; //For updating graphics that need updating every frame.
    public static Action PhysicsUpdates; //For objects that need to move on each physics update.
    public static Action PauseScripts; //For any code that should run when game is paused.
    public static Action UnPauseScripts; //Same as above, for code that runs when game is unpaused.

    //-Private Variables-//
    private bool isPaused = false;

    void Start()
    {
        PauseScripts += OnPause;
        UnPauseScripts += OnUnPause;
    }


    //FUNCTION: Update function, listens for input, updates necessary graphics.
    //CALLED BY: The unity game engine with every frame update.
    void Update () {

        if (GraphicalUpdates != null) //All graphics updated.
            GraphicalUpdates();
       
        //User input checked on the necessary keys, appropriate actions called and information passed.
        //Left and right turns.
        if (Input.GetKey(KeyCode.LeftArrow) && UserMovementInput != null) 
        {
            UserMovementInput(KeyCode.LeftArrow);
        }
        if (Input.GetKey(KeyCode.RightArrow) && UserMovementInput != null)
        {
            UserMovementInput(KeyCode.RightArrow);
        }

        //Forward movement.
        if (Input.GetKey(KeyCode.UpArrow) && UserMovementInput != null)
        {
            UserMovementInput(KeyCode.UpArrow);
        }

        //Pausing the game
        if (Input.GetKeyDown(KeyCode.Space) && PauseScripts != null)
        {
            
            if (!isPaused)
            {
                PauseScripts();

            }
            else
            {
                UnPauseScripts();
                
            }
        }

        //Listens for Escape key, quits program when pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //FUNCTION: Updating of all physics scripts, like movement.
    //CALLED BY: Unit engine with every physics update.
    void FixedUpdate()
    {
        if(PhysicsUpdates != null)
            PhysicsUpdates();
    }

    //FUNCTION: All Actions are emptied when the scene resets/unloads, to avoid errors of calling scripts that no longer exist.
    //CALLED BY: Unity game engine.
    void OnDestroy()
    {
        UserMovementInput = null;
        GraphicalUpdates = null;
        PhysicsUpdates = null;
        PauseScripts = null;
        UnPauseScripts = null;
}

    public void OnPause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void OnUnPause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
