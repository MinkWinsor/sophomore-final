using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD_PauseScreen : MonoBehaviour, IPausable {

    public Transform PauseScreenParentNode;
    public List<Transform> PauseScreenObjects;

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
    //OUTPUTS:
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
    //INPUTS:
    //OUTPUTS:
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
    //INPUTS:
    //OUTPUTS:
    public void OnUnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if (pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(false);
        }

    }
}
