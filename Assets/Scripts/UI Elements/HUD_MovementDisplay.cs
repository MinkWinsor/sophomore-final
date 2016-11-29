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

    //FUNCTION: Sets up functions to update on the UpdateScript update function.
    //CALLED BY: Unity game engine
    void Start () {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
        playerCC = playerRef.GetComponent<CharacterController>();
    }

    //FUNCTION:Updates function to represent which way player faces.
    //CALLED BY: UpdateScript.GraphicalUpdates action
    private void compassUpdate()
    {
        compass.transform.eulerAngles = new Vector3(0, 0, -playerRef.rotation.eulerAngles.y);
    }

    //FUNCTION: Updates speed slider to represent a ratio from 0 to max speed
    //CALLED BY: UpdateScript.GraphicalUpdates action
    void sliderUpdate () {
        if((Mathf.Abs(playerCC.velocity.x) > Mathf.Abs(playerCC.velocity.z))){
            mySlider.value = (Mathf.Abs(playerCC.velocity.x));
        }
        else
        {
            mySlider.value = (Mathf.Abs(playerCC.velocity.z));
        }
    }

    //FUNCTION: Stops compass and slider from updating
    //CALLED BY: UpdateScript.OnPause action
    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= sliderUpdate;
        UpdateScript.GraphicalUpdates -= compassUpdate;
    }

    //FUNCTION: Starts compass and slider updating
    //CALLED BY: UpdateScript.OnPause action
    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
    }
}
