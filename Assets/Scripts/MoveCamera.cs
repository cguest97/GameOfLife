using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    /* Parameters affecting camera movement */
    public float maxspeed = 2f;
    public float acceleration = 0.2f;
    public float deceleration = 0.05f;
    public float zoomspeed = 0.5f;

    private float currentspeedX;
    private float currentspeedY;

    /* Attach the camera object */
    public Camera myCamera;

	// Use this for initialization
	void Start () {
        currentspeedX = 0;
        currentspeedY = 0;
	}
	
	// Update is called once per frame
	void Update () {

        /* On key press add relevent velocity */
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            currentspeedX += acceleration;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            currentspeedX = currentspeedX - acceleration;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            currentspeedY += acceleration;            
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            currentspeedY = currentspeedY - acceleration;
        }

        /* Zoom */
        if (Input.mouseScrollDelta.y > 0) {
            if(myCamera.orthographicSize > zoomspeed)
                myCamera.orthographicSize += -zoomspeed;
        }
        else if (Input.mouseScrollDelta.y < 0) {
            myCamera.orthographicSize += zoomspeed;
        }

        /* Decelerate */
        float Xvel = 0.0f;
        float YVel = 0.0f;
        currentspeedX = Mathf.SmoothDamp(currentspeedX, 0, ref Xvel, deceleration);
        currentspeedY = Mathf.SmoothDamp(currentspeedY, 0, ref YVel, deceleration);

        /* Make sure we are never over our maximum speed */
        Mathf.Clamp(currentspeedX, -maxspeed, maxspeed);
        Mathf.Clamp(currentspeedY, -maxspeed, maxspeed);
        transform.position = new Vector3(transform.position.x + currentspeedX, transform.position.y + currentspeedY, transform.position.z);
	}
}
