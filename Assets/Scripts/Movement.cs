using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform VrCamera;

    public float FowardtoggleAngle = 30.00f;
    public float ForwardtoggleAngleCuttoff = 90.00f;

    public float speed = 3.0f;

    public bool moveForward;

    //public Transform cc;

    public Rigidbody cc;

    //public CharacterController cc;

    // Use this for initialization
    void Start ()
    {
        //cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (VrCamera.eulerAngles.x >= FowardtoggleAngle && VrCamera.eulerAngles.x < ForwardtoggleAngleCuttoff)
	    {
	        moveForward = true;
	    }
	    else
	    {
	        moveForward = false;
	    }

	    if (moveForward)
	    {

	        cc.velocity = transform.forward * speed;

	    }
	    else
	    {
	        cc.velocity = transform.forward * 0.0f;
	    }
    }

}
