using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD_PauseScreen : MonoBehaviour {

    public Transform PauseScreenParentNode;
    public List<Transform> PauseScreenObjects;

	// Use this for initialization
	void Start () {
        PauseScreenObjects = new List<Transform>();
        foreach (Transform child in PauseScreenParentNode)
        {
            PauseScreenObjects.Add(child);
        }

        foreach (Transform pauseElement in PauseScreenObjects)
        {
            pauseElement.gameObject.SetActive(false);
        }

        OnlyUpdateScript.PauseScripts += DisplayPauseScreen;
        OnlyUpdateScript.UnPauseScripts += HidePauseScreen;
    }

    public void DisplayPauseScreen()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if(!pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(true);
        }

    }

    public void HidePauseScreen()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if (pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(false);
        }

    }
}
