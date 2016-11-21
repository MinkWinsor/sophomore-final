using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Recycler : MonoBehaviour {

    public List<Transform> SpawnPositions;
    public List<Recyclable> RecyclableItems;

    protected int listIndex = 0;

    // Use this for initialization
    protected virtual void Start () {
        RecyclableItems = new List<Recyclable>();
        Recyclable.RecyclerAction += RecycleActionHandler;
    }

    protected virtual void RecycleActionHandler(Recyclable _r)
    {
        
         RecyclableItems.Add(_r);
        _r.gameObject.SetActive(false);
    }

    public virtual void RecycleOneObject()
    {
        RecyclableItems[listIndex].gameObject.SetActive(true);
        if (listIndex < RecyclableItems.Count - 1)
        {
            listIndex++;
        }
        else
        {
            listIndex = 0;
        }
    }

    protected Vector3 RandomPosition()
    {
        Vector3 tempTransform;
        tempTransform = SpawnPositions[UnityEngine.Random.Range(0, SpawnPositions.Count)].transform.position;
        return tempTransform;
    }
    
}
