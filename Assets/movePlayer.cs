using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public float speed = 5;
    public float rotateSpeed = 20;
    public float dragFactor = 0.5f;

    private Vector3 force;
    private CharacterController myCC;

	// Use this for initialization
	void Start () {

        myCC = GetComponent<CharacterController>();
        StartCoroutine(moveScript());
	}

    IEnumerator moveScript()
    {
        while (true)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("Force");
                force += transform.forward;
            }
                

            yield return new WaitForSeconds(0.1f);

            print(force);
            if (force.x > 0)
                force.x -= force.x * dragFactor;
            if (force.z > 0)
                force.z -= force.z * dragFactor;
            if (force.x < 0)
                force.x -= force.x * dragFactor;
            if (force.z < 0)
                force.z -= force.z * dragFactor;
        }


    }
	
	// Update is called once per frame
	void Update () {

        

        /*if (force.x != 0 || force.y != 0)
        {
            force -= transform.forward * dragFactor;
        }*/
        

        myCC.Move(force * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        
    }
}
