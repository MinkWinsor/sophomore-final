using UnityEngine;
using System.Collections;
using System;

public abstract class PowerUp : Recyclable {

    public static Action<PowerUp> PowerUpRecyclerAction;
    

    protected override void Start()
    {

        if (PowerUpRecyclerAction != null)
        {

            PowerUpRecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }

}
