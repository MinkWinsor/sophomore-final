using UnityEngine;
using System.Collections;
using System;

public class actionCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        actionBase.myAction += printBase;
        actionChild.myAction += printChild;
    }

    void printBase()
    {
        print("Base fired");
    }

    void printChild()
    {
        print("Child fired");
    }
}
