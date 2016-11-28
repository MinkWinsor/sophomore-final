/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class EnemyRecyclable : Recyclable {

    //-Public Variables-//
    public static Action<EnemyRecyclable> EnemyRecyclerAction;
    public Transform targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;

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
