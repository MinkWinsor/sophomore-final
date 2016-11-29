/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpRecycler : Recycler {

    //FUNCTION:
    //CALLED BY:
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        PowerUp.RecyclerAction += RecycleActionHandler;
    }
    


    
}
