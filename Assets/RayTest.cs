// Draws a line in the scene view going through a point 200 pixels
// from the lower-left corner of the screen
using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour
{
    Camera myCamera;
    Ray ray;

    void Start()
    {
        myCamera = GetComponent<Camera>();
        ray = myCamera.ViewportPointToRay(Input.mousePosition);
    }


    void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }

    public void drawRay()
    {
        ray = myCamera.ScreenPointToRay(Input.mousePosition);
        
    }
}