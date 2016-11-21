using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecycleEnemies : Recycler
{
    //public new List<Recyclable> RecyclableItems;
    public float TimeToWait = 1;
    public bool CanSpawn = true;

    void Start()
    {
        RecyclableItems = new List<Recyclable>();
        EnemyRecyclable.EnemyRecyclerAction += RecycleActionHandler;
        StartCoroutine(SpawnOnTimer());
    }

    protected override void RecycleActionHandler(Recyclable _r)
    {
        print("Called");
        if (_r.GetComponent<MoveOnNavMesh>() != null)
        {
            _r.GetComponent<MoveOnNavMesh>().StopMoving();
        }
        base.RecycleActionHandler(_r);
        
    }

    public override void RecycleOneObject()
    {
        for(int tryCount = 0; tryCount < 6; tryCount++) //Ensures that if all objects are in use, recycler won't pour in extra efforts to recycle something.
        {
            if (!RecyclableItems[listIndex].gameObject.activeSelf)
            {
                RecyclableItems[listIndex].transform.position = RandomPosition();
                base.RecycleOneObject();
                if (listIndex > 0)
                {
                    startNav(listIndex - 1);
                }
                else
                {
                    startNav(RecyclableItems.Count - 1);
                }
                tryCount = 6;
            }
            else
            {
                listIndex++;
            }
        }
        
        
    }
    
    private void startNav(int _index)
    {
        if (RecyclableItems[_index].GetComponent<MoveOnNavMesh>() != null)
        {
            RecyclableItems[_index].GetComponent<MoveOnNavMesh>().StartMoving();
        }
    }

    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(TimeToWait);
            RecycleOneObject();
        }
    }
}

