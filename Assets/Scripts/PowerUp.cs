/*
 This script is the basis for power ups. It's important that power ups derive from here so that
 the power up recycler can recycle all types of power ups at once by using a generic type.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public abstract class PowerUp : Recyclable {

    //-Public Variables-//
    public static Action<PowerUp> RecyclerAction; //Used to add itself to lists in the recycler.

    //FUNCTION: If a recycler exists, and has added itself to the action, we pass this object as a PowerUp to the Recycler.
    //CALLED BY: Unity game engine
    protected override void Start()
    {
        //This start function must be called AFTER the recycler start function.
        if (RecyclerAction != null)
        {

            RecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }

    //FUNCTION: All power ups must collide with the player, as that is when they do what power ups do.
    protected abstract void OnTriggerEnter(Collider other);

}
