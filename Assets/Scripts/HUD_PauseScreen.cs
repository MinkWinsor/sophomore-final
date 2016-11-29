/*
 This script is for displaying the pause screen, like buttons to restart and such.
 All it needs is a an object, and all the children of that object will be displayed on pause.
 */

//Required Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD_PauseScreen : MonoBehaviour, IPausable {

    //-Public Variables-//
    public Transform PauseScreenParentNode; //Parent node of pause screen objects.
    public List<Transform> PauseScreenObjects; //List of objects.

    //FUNCTION: Start function, compiles list of pause screen objects, subscribes to pause actions called from update script.
    //CALLED BY: Unity game engine
    void Start () {
        //Pause screen objects added to list.
        PauseScreenObjects = new List<Transform>();
        foreach (Transform child in PauseScreenParentNode)
        {
            PauseScreenObjects.Add(child);
        }

        //Objects hidden, if visible.
        OnUnPause();

        //Subscribe to actions for calling pause
        UpdateScript.PauseScripts += OnPause;
        UpdateScript.UnPauseScripts += OnUnPause;
    }

    //FUNCTION: Shows the pause screen.
    //CALLED BY: Action in the update script when game is paused.
    public void OnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if(!pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(true);
        }

    }

    //FUNCTION: Hides the pause screen.
    //CALLED BY: Action in the update script when game is paused.
    public void OnUnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if (pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(false);
        }

    }
}
