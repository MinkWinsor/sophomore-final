/*
 This script is for displaying the HUD elements of speed and direction.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUD_MovementDisplay : MonoBehaviour, IPausable {

    //-Public Variables-//
    public Slider mySlider;
    public Image compass;
    public Transform playerRef;
   
    //-Private Variables-//
    private CharacterController playerCC;

	// Use this for initialization
	void Start () {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
        //playerRefScript = playerRef.GetComponent<movePlayer>();
        playerCC = playerRef.GetComponent<CharacterController>();
    }

    private void compassUpdate()
    {
        compass.transform.eulerAngles = new Vector3(0, 0, -playerRef.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void sliderUpdate () {
        //print(playerCC.velocity);
        if((Mathf.Abs(playerCC.velocity.x) > Mathf.Abs(playerCC.velocity.z))){
            mySlider.value = (Mathf.Abs(playerCC.velocity.x));
        }
        else
        {
            mySlider.value = (Mathf.Abs(playerCC.velocity.z));
        }

    }

    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= sliderUpdate;
        UpdateScript.GraphicalUpdates -= compassUpdate;
    }

    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
    }
}
