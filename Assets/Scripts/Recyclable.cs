/*
 Base class for a Recyclable object. It's important to note that even though a start function example is shown, it should NOT be used. Overriding is required.
 This is not because the script would not work. it could. But if you use the base class script to collect objects in a list, you will get ALL the Recyclable objects.
 This includes bullets, enemies, etc.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public abstract class Recyclable : MonoBehaviour {

    //-Public Variables-//
    //public static Action<Recyclable> RecyclerAction; //Each script should have their own version of this.

    //FUNCTION: This function should always be overriden. The recyclerAction should be reused with a class-specific name.
    //CALLED BY: Unity Game Engine
    protected abstract void Start();
        /*if (RecyclerAction != null)
        {

            RecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }*/
	
}



