using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpRecycler : Recycler {

    void Start()
    {
        RecyclableItems = new List<Recyclable>();
        PowerUp.PowerUpRecyclerAction += RecycleActionHandler;
    }
    
}
