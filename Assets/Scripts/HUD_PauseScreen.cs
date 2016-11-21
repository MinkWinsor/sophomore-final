using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD_PauseScreen : MonoBehaviour, IPausable {

    public Transform PauseScreenParentNode;
    public List<Transform> PauseScreenObjects;

	// Use this for initialization
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

    public void OnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if(!pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(true);
        }

    }

    public void OnUnPause()
    {
        foreach (Transform pauseElement in PauseScreenObjects)
        {
            if (pauseElement.gameObject.activeSelf)
                pauseElement.gameObject.SetActive(false);
        }

    }
}
