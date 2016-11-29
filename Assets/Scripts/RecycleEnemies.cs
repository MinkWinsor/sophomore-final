/*
 Enemy recycler. Great thing about this script is it recycles any type of enemy.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecycleEnemies : Recycler
{
    //-Public Variables-//
    public float TimeToWait = 1;
    public bool CanSpawn = true;

    //FUNCTION: Sets up list, adds itself to EnemyRecycleAction to get all enemies to be recycled.
    //CALLED BY: Unity game engine
    protected override void Start()
    {
        RecyclableItems = new List<Recyclable>();
        EnemyRecyclable.EnemyRecyclerAction += RecycleActionHandler;
        StartCoroutine(SpawnOnTimer());
    }

    //FUNCTION: Adds all recyclables to list
    //CALLED BY: EnemyRecyclable.EnemyRecyclerAction action
    //INPUTS: The recyclable to be added.
    protected override void RecycleActionHandler(Recyclable _r)
    {
        if (_r.GetComponent<MoveOnNavMesh>() != null)
        {
            _r.GetComponent<MoveOnNavMesh>().StopMoving();
        }
        base.RecycleActionHandler(_r);
        
    }

    //FUNCTION: Recycles one enemy at one of the spawn positions.
    //CALLED BY: Recycler child scripts, or outside scripts.
    //OUTPUTS: Int of object that was recycled.
    public override int RecycleOneObject()
    {
        int lastIndex = -1;
        for (int tryCount = 0; tryCount < 6; tryCount++) //Ensures that if all objects are in use, recycler won't pour in extra efforts to recycle something.
        {
            
            if (!RecyclableItems[listIndex].gameObject.activeSelf) //Only recycles inactive objects.
            {
                RecyclableItems[listIndex].transform.position = RandomPosition();
                lastIndex = base.RecycleOneObject();
                startNav(lastIndex);
                
                tryCount = 6;
            }
            else
            {
                lastIndex = listIndex; //Moves listIndex if current listIndex is in use and won't be recycled.
                if (listIndex < RecyclableItems.Count - 1)
                {
                    listIndex++;
                }
                else
                {
                    listIndex = 0;
                }

            }

        }
        return lastIndex;
        
    }

    //FUNCTION: Starts the enemy moving towards the player.
    //CALLED BY: RecycleOneObject
    //INPUTS: index of object to start navigation of.
    private void startNav(int _index)
    {
        if (RecyclableItems[_index].GetComponent<MoveOnNavMesh>() != null)
        {
            RecyclableItems[_index].GetComponent<MoveOnNavMesh>().StartMoving();
        }
    }

    //FUNCTION: Spawns enemy on a timer.
    //CALLED BY: Start function
    //OUTPUTS: Reference to self.
    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(TimeToWait);
            RecycleOneObject(); //Spawns enemy.
        }
    }
}

