/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpRecycler : Recycler {

    public float TimeBetweenSpawns = 2f;
    public bool CanSpawn = true;
    public float HeightOffset = 1;


    private int index;

    //FUNCTION:
    //CALLED BY:
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        PowerUp.RecyclerAction += RecycleActionHandler;
        StartCoroutine(SpawnOnTimer());
    }
    

    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(TimeBetweenSpawns);

            foreach(Recyclable item in RecyclableItems)
            {
                item.gameObject.SetActive(false);
            }

            foreach (Transform spawnPoint in SpawnPositions)
            {
                index = RecycleOneObject();
                RecyclableItems[index].transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + HeightOffset, spawnPoint.position.z);
            }
        }
        


        
    }


    
}
