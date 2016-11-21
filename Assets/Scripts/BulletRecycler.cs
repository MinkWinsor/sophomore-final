using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletRecycler : Recycler {

    public new List<Bullet> RecyclableItems;

    protected override void Start()
    {
        print("Check");
        RecyclableItems = new List<Bullet>();
        Bullet.BulletRecyclerAction += RecycleActionHandler;
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
