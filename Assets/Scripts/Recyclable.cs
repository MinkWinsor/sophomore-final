/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public abstract class Recyclable : MonoBehaviour {

    //-Public Variables-//
    public static Action<Recyclable> RecyclerAction;

    //FUNCTION:
    //CALLED BY:
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



