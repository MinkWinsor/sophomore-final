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
    public float speed = 100;
    public float damagePerBullet = 10;

    //FUNCTION: On start, bullet adds itself to recycler list.
    //CALLED BY: Unity game engine
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

    //FUNCTION: Moves bullet forward every physics update.
    //CALLED BY: UpdateScript.PhysicsUpdates
    private void moveBullet()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    //FUNCTION: When bullet hits, damage is dealt to player.
    //CALLED BY: Unity game engine
    //INPUTS: Collider of player.
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitPlayer>())
        {
            other.GetComponent<UnitPlayer>().TakeDamage(damagePerBullet);
        }

        gameObject.SetActive(false); //Bullet deactivated so it can be used again.
    }
}
