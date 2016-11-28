using UnityEngine;
using System.Collections;
using System;

public abstract class PowerUp : Recyclable {

    public static Action<PowerUp> PowerUpRecyclerAction;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
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
