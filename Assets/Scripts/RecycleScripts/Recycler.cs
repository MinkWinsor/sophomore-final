/*
 Base recycler script. 
 These are functions to help manage a list of recyclable objects.
 The RecycleActionHandler and RecycleOneObject functions provide the main functionality.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Recycler : MonoBehaviour {

    //-Public Variables-//
    public List<Transform> SpawnPositions; //Optional list of spawn positions.
    public List<Recyclable> RecyclableItems;
    public int listIndex = 0;

    //FUNCTION: All scripts deriving from this class need the start function in order to add themselves to the Recyclable action.
    protected abstract void Start(); /*{
        Recyclable.RecyclerAction += RecycleActionHandler; //Example of implementation
    }*/

    //FUNCTION: Adds the Recyclable to this objects list.
    //CALLED BY: Actions in Recyclable objects
    //INPUTS: Recyclable to add to the list.
    protected virtual void RecycleActionHandler(Recyclable _r)
    {
         RecyclableItems.Add(_r);
        _r.gameObject.SetActive(false);
    }

    //FUNCTION: Activates current object in list and moves list to next object.
    //CALLED BY: Child recycler scripts.
    //OUTPUTS: An int representing the index of the object that was recycled.
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
            return RecyclableItems.Count - 1; //We return the previous index because if we want to modify the object just recycled, we need that index.
        }
    }

    //FUNCTION: Gives one of the spawn points at random.
    //CALLED BY: Recyclers, often those spawning enemies or such at random points.
    //OUTPUTS: A vector3 for the new position.
    protected Vector3 RandomPosition()
    {
        Vector3 tempTransform;
        tempTransform = SpawnPositions[UnityEngine.Random.Range(0, SpawnPositions.Count)].transform.position;
        return tempTransform;
    }
    
}
