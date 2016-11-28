/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public abstract class Recyclable : MonoBehaviour {

    public static Action<Recyclable> RecyclerAction;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    protected virtual void Start () {
        if (RecyclerAction != null)
        {

            RecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }
	
}



