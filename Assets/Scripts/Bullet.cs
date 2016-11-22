using UnityEngine;
using System.Collections;
using System;

public class Bullet : Recyclable {

    public static Action<Bullet> BulletRecyclerAction;

    private Vector3 targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;


    protected override void Start()
    {
        OnlyUpdateScript.PhysicsUpdates += moveBullet;

        if (BulletRecyclerAction != null)
        {

            BulletRecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }

    public void setTarget(Vector3 newTarget)
    {
        targetPos = newTarget;
    }

    private void moveBullet()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
    
    void OnTriggerEnter(Collider other)
    {
        print("COLLISION");
        if (other.GetComponent<UnitPlayer>())
        {
            other.GetComponent<UnitPlayer>().TakeDamage(damagePerBullet);
        }
    }
}
