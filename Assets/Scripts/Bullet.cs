using UnityEngine;
using System.Collections;
using System;

public class Bullet : Recyclable {

    public static Action<Bullet> BulletRecyclerAction;

    //private Vector3 targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;


    protected override void Start()
    {
        OnlyUpdateScript.GraphicalUpdates += moveBullet;

        if (BulletRecyclerAction != null)
        {

            BulletRecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }

    /*public void SetTarget(Vector3 newTarget)
    {
        float step = speed * Time.deltaTime;
        print(targetPos);
        targetPos = Vector3.MoveTowards(transform.position, newTarget, step);
        print(targetPos);
    }*/

    private void moveBullet()
    {
        
        transform.position += transform.forward * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitPlayer>())
        {
            other.GetComponent<UnitPlayer>().TakeDamage(damagePerBullet);
        }

        gameObject.SetActive(false);
    }
}
