using UnityEngine;
using System.Collections;
using System;

public class actionChild : actionBase {

    public static new Action myAction;
    // Use this for initialization
    void Start () {
        print("child");
        myAction();
	}
	
}
