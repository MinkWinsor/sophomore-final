using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecycleEnemies : Recycler
{
    
    public float TimeToWait = 1;
    public bool CanSpawn = true;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(SpawnOnTimer());
    }

    protected override void RecycleActionHandler(Recyclable _r)
    {
        if (_r.GetComponent<MoveOnNavMesh>() != null)
        {
            _r.GetComponent<MoveOnNavMesh>().StopMoving();
        }
        base.RecycleActionHandler(_r);
        
    }

    public override void RecycleOneObject()
    {
        if (!RecyclableItems[listIndex].gameObject.activeSelf)
        {

            
            

            if (RecyclableItems[listIndex].GetComponent<MoveOnNavMesh>() != null)
            {
                RecyclableItems[listIndex].GetComponent<MoveOnNavMesh>().StartMoving();
            }
            RecyclableItems[listIndex].transform.position = RandomPosition();
            base.RecycleOneObject();
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

