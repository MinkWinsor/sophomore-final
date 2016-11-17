using UnityEngine;
using System.Collections;
using System;

public class OnlyUpdateScript : MonoBehaviour {

    public static Action<KeyCode> UserMovementInput;
    public static Action GraphicalUpdates;
	
	// Update is called once per frame
    //This is the script I'm going to use all of the update calls in.
	void Update () {

        GraphicalUpdates();

        print("Update");

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


    }
}
