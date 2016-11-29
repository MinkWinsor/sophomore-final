/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class EnemyRecyclable : Recyclable {

    //-Public Variables-//
    public static Action<EnemyRecyclable> EnemyRecyclerAction;

    //FUNCTION:
    //CALLED BY:
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
