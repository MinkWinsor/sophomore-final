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

    //FUNCTION:
    //CALLED BY:
    void Start () {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
        playerCC = playerRef.GetComponent<CharacterController>();
    }

    //FUNCTION:
    //CALLED BY:
    private void compassUpdate()
    {
        compass.transform.eulerAngles = new Vector3(0, 0, -playerRef.rotation.eulerAngles.y);
    }

    //FUNCTION:
    //CALLED BY:
    void sliderUpdate () {
        if((Mathf.Abs(playerCC.velocity.x) > Mathf.Abs(playerCC.velocity.z))){
            mySlider.value = (Mathf.Abs(playerCC.velocity.x));
        }
        else
        {
            mySlider.value = (Mathf.Abs(playerCC.velocity.z));
        }
    }

    //FUNCTION:
    //CALLED BY:
    public void OnPause()
    {
        UpdateScript.GraphicalUpdates -= sliderUpdate;
        UpdateScript.GraphicalUpdates -= compassUpdate;
    }

    //FUNCTION:
    //CALLED BY:
    public void OnUnPause()
    {
        UpdateScript.GraphicalUpdates += sliderUpdate;
        UpdateScript.GraphicalUpdates += compassUpdate;
    }
}
