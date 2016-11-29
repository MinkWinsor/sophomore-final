/*
Script for BulletRecycler. Recycles enemy bullets, one recycler handles bullets for all enemies.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletRecycler : Recycler {
    
    //FUNCTION: Sets up list by subscribing to bullet actions.
    //CALLED BY: Unity game engine.
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        Bullet.RecyclerAction += RecycleActionHandler; //Bullet action will add self to list.
    }

    //FUNCTION: Fires a bullet, given start point and end point. Bullets move forward, so merely points bullet at target.
    //CALLED BY: Units that want to fire a bullet.
    //INPUTS: Start position of bullet and target.
    public void FireBullet(Vector3 start, Vector3 end)
    {
        RecyclableItems[listIndex].transform.position = start;
        RecyclableItems[listIndex].transform.LookAt(end);
        RecycleOneObject();
    }
}
