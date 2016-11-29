using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletRecycler : Recycler {

    //public new List<Recyclable> RecyclableItems;


    //FUNCTION:
    //CALLED BY:
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        Bullet.RecyclerAction += RecycleActionHandler;
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    public void FireBullet(Vector3 start, Vector3 end)
    {
        RecyclableItems[listIndex].transform.position = start;
        RecyclableItems[listIndex].transform.LookAt(end);
        RecycleOneObject();
    }
}
