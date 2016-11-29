/*
 Bullet script. Bullets are recyclable objects that can be used multiple times, and hurt whatever they hit.
 Bullets should only be on layers that can hit Units with IHealth.
 Currently in the game, only enemies have bullets.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class Bullet : Recyclable {

    //-Public Variables-//
    public static Action<Bullet> RecyclerAction;
    //private Vector3 targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;

    //FUNCTION:
    //CALLED BY:
    protected override void Start()
    {
        UpdateScript.PhysicsUpdates += moveBullet;

        if (RecyclerAction != null)
        {

            RecyclerAction(this);
        }
        else
        {
            print("RECYCLER NULL");
        }
    }
    

    //FUNCTION:
    //CALLED BY:
    private void moveBullet()
    {
        
        transform.position += transform.forward * Time.deltaTime;
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitPlayer>())
        {
            other.GetComponent<UnitPlayer>().TakeDamage(damagePerBullet);
        }

        gameObject.SetActive(false);
    }
}
