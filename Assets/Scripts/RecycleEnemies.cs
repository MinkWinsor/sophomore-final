/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecycleEnemies : Recycler
{
    //-Public Variables-//
    //public new List<Recyclable> RecyclableItems;
    public float TimeToWait = 1;
    public bool CanSpawn = true;

    //FUNCTION:
    //CALLED BY:
    void Start()
    {
        RecyclableItems = new List<Recyclable>();
        EnemyRecyclable.EnemyRecyclerAction += RecycleActionHandler;
        StartCoroutine(SpawnOnTimer());
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    protected override void RecycleActionHandler(Recyclable _r)
    {
        if (_r.GetComponent<MoveOnNavMesh>() != null)
        {
            _r.GetComponent<MoveOnNavMesh>().StopMoving();
        }
        base.RecycleActionHandler(_r);
        
    }

    //FUNCTION:
    //CALLED BY:
    //OUTPUTS:
    public override int RecycleOneObject()
    {
        int lastIndex = 0;
        for (int tryCount = 0; tryCount < 6; tryCount++) //Ensures that if all objects are in use, recycler won't pour in extra efforts to recycle something.
        {
            
            if (!RecyclableItems[listIndex].gameObject.activeSelf)
            {
                RecyclableItems[listIndex].transform.position = RandomPosition();
                lastIndex = base.RecycleOneObject();
                startNav(lastIndex);
                
                tryCount = 6;
            }

        }
        return lastIndex;
        
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    private void startNav(int _index)
    {
        if (RecyclableItems[_index].GetComponent<MoveOnNavMesh>() != null)
        {
            RecyclableItems[_index].GetComponent<MoveOnNavMesh>().StartMoving();
        }
    }

    //FUNCTION:
    //CALLED BY:
    //OUTPUTS:
    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(TimeToWait);
            RecycleOneObject();
        }
    }
}

