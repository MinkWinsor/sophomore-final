using UnityEngine;
using System.Collections;
using System;

public class EnemyRecyclable : Recyclable {

    public static Action<EnemyRecyclable> EnemyRecyclerAction;

    public Transform targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;


    protected override void Start()
    {
        print("Recycling");
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
