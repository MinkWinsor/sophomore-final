using UnityEngine;
using System.Collections;

public class Mouse_Position_Calculation : MonoBehaviour {

    public Transform LowerLeft;
    public Transform LowerRight;
    public Transform UpperLeft;
    public Transform UpperRight;
    public Transform moveCube;
    public Collider_Script myCScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown() {
        myCScript.lookAt(Input.mousePosition);

        //Debug.Log("Mouse Clicked: " + Input.mousePosition);
        float _xRelativePosition = Input.mousePosition.x / Screen.width;
        float _zRelativePosition = Input.mousePosition.y / Screen.height;
        //Debug.Log("Relative Position: " + _xRelativePosition + _zRelativePosition);


        
        float _topAverage = (UpperRight.transform.position.x * _xRelativePosition) + (UpperLeft.transform.position.x * (1 - _xRelativePosition));
        float _bottomAverage = (LowerRight.transform.position.x * _xRelativePosition) + (LowerLeft.transform.position.x * (1 - _xRelativePosition));
        //Debug.Log(UpperLeft.transform.position.z + LowerLeft.transform.position.z);
        Vector3 _middleAverage = new Vector3(
            ((_topAverage * _zRelativePosition) + (_bottomAverage * (1 - _zRelativePosition))),
            (0),

            (((UpperLeft.transform.position.z * _zRelativePosition) + (LowerLeft.transform.position.z * (1 - _zRelativePosition))))
            );
        

        moveCube.position = _middleAverage;


    }


    /*(
            (((UpperLeft.transform.position.z * _zRelativePosition) + (LowerLeft.transform.position.z * (1 - _zRelativePosition)))
            + ((UpperLeft.transform.position.z + LowerLeft.transform.position.z) / 2)*/
}
