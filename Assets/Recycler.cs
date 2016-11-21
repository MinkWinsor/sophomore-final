using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recycler : MonoBehaviour {

    public List<Recyclable> RecyclableItems;

    protected int listIndex = 0;

    // Use this for initialization
    protected virtual void Start () {
        RecyclableItems = new List<Recyclable>();
        Recyclable.RecyclerAction += RecycleActionHandler;
    }

    protected virtual void RecycleActionHandler(Recyclable _r)
    {
        print("adding to list");
         RecyclableItems.Add(_r);
        _r.gameObject.SetActive(false);
    }

    public virtual void RecycleOneObject()
    {
        if (listIndex < RecyclableItems.Count - 1)
        {
            listIndex++;
        }
        else
        {
            listIndex = 0;
        }

        RecyclableItems[listIndex].gameObject.SetActive(true);

        
    }
    
}
