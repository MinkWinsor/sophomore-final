/*
 All Enemies use this script, and this allows enemies to be recycled and spawned at intervals to head at the player.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class EnemyRecyclable : Recyclable {

    //-Public Variables-//
    public static Action<EnemyRecyclable> EnemyRecyclerAction; //Used to add itself to lists in the recycler.

    //FUNCTION: If a recycler exists, and has added itself to the action, we pass this object as an enemy.
    //CALLED BY: Unity game engine
    protected override void Start()
    {
        if (EnemyRecyclerAction != null)
        {

            EnemyRecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }
}