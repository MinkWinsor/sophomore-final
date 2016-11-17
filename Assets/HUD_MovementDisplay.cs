using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUD_MovementDisplay : MonoBehaviour {

    public Slider mySlider;
    public Image compass;
    public Transform playerRef;

    private movePlayer playerRefScript;

	// Use this for initialization
	void Start () {
        OnlyUpdateScript.GraphicalUpdates += sliderUpdate;
        OnlyUpdateScript.GraphicalUpdates += compassUpdate;

        playerRefScript = playerRef.GetComponent<movePlayer>();
    }

    private void compassUpdate()
    {
        compass.transform.eulerAngles = new Vector3(0, 0, -playerRef.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void sliderUpdate () {
        print(playerRefScript.getRelativeSpeed());
        mySlider.value = playerRefScript.getRelativeSpeed();
       
	}
}
