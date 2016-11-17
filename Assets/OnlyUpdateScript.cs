using UnityEngine;
using System.Collections;
using System;

public class OnlyUpdateScript : MonoBehaviour {

    public static Action<KeyCode> UserMovementInput;
    public static Action GraphicalUpdates;
    public static Action PhysicsUpdates;
	
	// Update is called once per frame
    //This is the script I'm going to use all of the update calls in.
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

        PhysicsUpdates();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }




}
