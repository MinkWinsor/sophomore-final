/*
 
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Recycler : MonoBehaviour {

    public List<Transform> SpawnPositions;
    public List<Recyclable> RecyclableItems;

    public int listIndex = 0;

    // Use this for initialization
    /*protected virtual void Start () {
        Recyclable.RecyclerAction += RecycleActionHandler;
    }*/

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    protected virtual void RecycleActionHandler(Recyclable _r)
    {
        
         RecyclableItems.Add(_r);
        _r.gameObject.SetActive(false);
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    public virtual int RecycleOneObject()
    {
        RecyclableItems[listIndex].gameObject.SetActive(true);
        if (listIndex < RecyclableItems.Count - 1)
        {
            listIndex++;
            
            return listIndex - 1;
        }
        else
        {
            listIndex = 0;
            return RecyclableItems.Count - 1;
        }
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
    protected Vector3 RandomPosition()
    {
        Vector3 tempTransform;
        tempTransform = SpawnPositions[UnityEngine.Random.Range(0, SpawnPositions.Count)].transform.position;
        return tempTransform;
    }
    
}
