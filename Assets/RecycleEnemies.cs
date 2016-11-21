using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecycleEnemies : Recycler
{
    public Transform SpawnPosition;
    public float TimeToWait = 1;
    public bool CanSpawn = true;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(SpawnOnTimer());
    }

    public override void RecycleOneObject()
    {
        base.RecycleOneObject();
        RecyclableItems[listIndex].transform.position = SpawnPosition.position;
        if (RecyclableItems[listIndex].GetComponent<MoveOnNavMesh>() != null)
        {
            RecyclableItems[listIndex].GetComponent<MoveOnNavMesh>().enabled = true;
        }
    }

    protected override void RecycleActionHandler(Recyclable _r)
    {
        if (_r.GetComponent<MoveOnNavMesh>() != null)
        {
            _r.GetComponent<MoveOnNavMesh>().enabled = false;
        }
        base.RecycleActionHandler(_r);
    }

    IEnumerator SpawnOnTimer()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(TimeToWait);
            RecycleOneObject();
            print("Spawning");
        }
    }
}

