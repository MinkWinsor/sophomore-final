using UnityEngine;
using System.Collections;
using System;

public class Recyclable : MonoBehaviour {

    public static Action<Recyclable> RecyclerAction;

    // Use this for initialization
    protected virtual void Start () {
        if (RecyclerAction != null)
        {
            RecyclerAction(this);
        }
    }
	
}
