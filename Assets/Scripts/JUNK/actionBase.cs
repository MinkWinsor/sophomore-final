using UnityEngine;
using System.Collections;
using System;

public class actionBase : MonoBehaviour {

    public static Action myAction;
	// Use this for initialization
	void Start () {
        myAction();
	}
	
}
