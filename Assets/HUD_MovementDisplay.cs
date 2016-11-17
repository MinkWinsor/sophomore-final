using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUD_MovementDisplay : MonoBehaviour {

    public Slider mySlider;
    public Image compass;
    public Transform playerRef;
    private Vector3 lastPlayerPos;
    public CharacterController playerCC;
    //private movePlayer playerRefScript;

	// Use this for initialization
	void Start () {
        OnlyUpdateScript.GraphicalUpdates += sliderUpdate;
        OnlyUpdateScript.GraphicalUpdates += compassUpdate;
        lastPlayerPos = playerRef.transform.position;
        //playerRefScript = playerRef.GetComponent<movePlayer>();
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
        //lastPlayerPos = playerRef.transform.position;
    }
}
