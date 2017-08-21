using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBOXcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal Joystick 1") > 0.5f)
            Debug.Log("Joystick 1");
        if (Input.GetAxis("Horizontal Joystick 2") > 0.5f)
            Debug.Log("Joystick 2");
    }
}
