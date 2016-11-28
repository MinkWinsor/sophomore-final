using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD_PauseScreen : MonoBehaviour, IPausable {

    //-Public Variables-//
    public Transform PauseScreenParentNode;
    public List<Transform> PauseScreenObjects;

    //FUNCTION:
    //CALLED BY:
    void Start () {
        PauseScreenObjects = new List<Transform>();
        foreach (Transform child in PauseScreenParentNode)
        {
            PauseScreenObjects.Add(child);
        }

        OnUnPause();

        OnlyUpdateScript.PauseScripts += OnPause;
        OnlyUpdateScript.UnPauseScripts += OnUnPause;
    }

    //FUNCTION:
    //CALLED BY:
    public void OnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if(!pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(true);
        }

    }

    //FUNCTION:
    //CALLED BY:
    public void OnUnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if (pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(false);
        }

    }
}
