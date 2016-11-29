/*
 This script spawns PowerUp objects at all locations you specify.
 Takes all powerups, good and bad alike, which causes pseudo-randomization.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpRecycler : Recycler {

    //-Private Variables-//
    private int index;

    //-Public Variables-//
    public float TimeBetweenSpawns = 3f;
    public bool CanSpawn = true;
    public float HeightOffset = 1;
    

    //FUNCTION: Function adds to list to receive all PowerUp recyclables. Should run before the recyclable function.
    //CALLED BY: Unity game engine
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        PowerUp.RecyclerAction += RecycleActionHandler;
        StartCoroutine(SpawnOnTimer()); //Recycler uses timer to spawn powerups.
    }
    
    //FUNCTION: Spawns power ups on spawn points on a timer.
    //CALLED BY: Start function
    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn) //Can be stopped by setting this to false.
        {
            yield return new WaitForSeconds(TimeBetweenSpawns); //Runs at time specified.

            foreach(Recyclable item in RecyclableItems) //Sets powerups to false to clear current powerups.
            {
                item.gameObject.SetActive(false);
            }

            foreach (Transform spawnPoint in SpawnPositions) //Sets powerup to each spawn location.
            {
                index = RecycleOneObject();
                RecyclableItems[index].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + HeightOffset, spawnPoint.position.z);
            }
        }
        


        
    }


    
}
