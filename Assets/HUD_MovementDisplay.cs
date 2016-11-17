﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUD_MovementDisplay : MonoBehaviour {

    public Slider mySlider;
    public Image compass;
    public Transform playerRef;
    private Vector3 lastPlayerPos;
    private CharacterController playerCC;
    private movePlayer playerRefScript;

	// Use this for initialization
	void Start () {
        OnlyUpdateScript.GraphicalUpdates += sliderUpdate;
        OnlyUpdateScript.GraphicalUpdates += compassUpdate;
        lastPlayerPos = playerRef.transform.position;
        playerRefScript = playerRef.GetComponent<movePlayer>();
        playerCC = playerRef.GetComponent<CharacterController>();
    }

    private void compassUpdate()
    {
        compass.transform.eulerAngles = new Vector3(0, 0, -playerRef.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void sliderUpdate () {
        //print(playerRefScript.getRelativeSpeed());
        //mySlider.value = playerRefScript.getRelativeSpeed();
        //Vector3 tempVector = ((playerRef.transform.position + lastPlayerPos) / (playerRef.transform.position + (movePlayer.speed, movePlayer.speed, movePlayer.speed) )    );
        print(playerCC.velocity);
        if((Mathf.Abs(playerCC.velocity.x) > Mathf.Abs(playerCC.velocity.z))){
            mySlider.value = (Mathf.Abs(playerCC.velocity.x));
        }
        else
        {
            mySlider.value = (Mathf.Abs(playerCC.velocity.z));
        }
        //mySlider.value = ((Mathf.Abs(playerCC.velocity.x) + Mathf.Abs(playerCC.velocity.z)) / playerRefScript.speed * 2);
        //lastPlayerPos = playerRef.transform.position;
    }
}
