/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System;

public class Bullet : Recyclable {

    public static Action<Bullet> RecyclerAction;

    //private Vector3 targetPos;
    public float speed = 100;
    public float damagePerBullet = 10;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    protected override void Start()
    {
        UpdateScript.GraphicalUpdates += moveBullet;

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
    //INPUTS:
    //OUTPUTS:
    private void moveBullet()
    {
        
        transform.position += transform.forward * Time.deltaTime;
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitPlayer>())
        {
            other.GetComponent<UnitPlayer>().TakeDamage(damagePerBullet);
        }

        gameObject.SetActive(false);
    }
}
