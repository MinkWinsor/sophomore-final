using UnityEngine;
using System.Collections;
using System;

public class Bullet : Recyclable {

    public static new Action<Recyclable> RecyclerAction;

    public Transform targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;


    protected override void Start()
    {
        OnlyUpdateScript.PhysicsUpdates += moveBullet;
        
        base.Start();
    }



    private void moveBullet()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
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
