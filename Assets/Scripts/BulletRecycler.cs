using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletRecycler : Recycler {

    //public new List<Recyclable> RecyclableItems;

    void Start()
    {
        RecyclableItems = new List<Recyclable>();
        Bullet.BulletRecyclerAction += RecycleActionHandler;
    }

    public override void RecycleOneObject()
    {
        base.RecycleOneObject();
    }

    public void FireBullet(Vector3 start, Vector3 end)
    {
        RecyclableItems[listIndex].transform.position = start;
        RecyclableItems[listIndex].transform.LookAt(end);
        RecycleOneObject();
    }
}
