using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletRecycler : Recycler {

	
    protected override void Start()
    {
        print("Check");
        RecyclableItems = new List<Recyclable>();
        Bullet.RecyclerAction += RecycleActionHandler;
    }

    public override void RecycleOneObject()
    {
        base.RecycleOneObject();
    }

    public void FireBullet(Vector3 start, Vector3 end)
    {
        print(RecyclableItems.Count);
        RecycleOneObject();
    }
}
