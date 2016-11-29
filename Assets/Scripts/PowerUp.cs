﻿/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public abstract class PowerUp : Recyclable {

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

    protected abstract void OnTriggerEnter(Collider other);

}
