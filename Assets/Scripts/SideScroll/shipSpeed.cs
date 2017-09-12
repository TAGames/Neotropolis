/*
* Hilfsscript, was die erzeugten Hintergrundships bewegt                              
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSpeed : MonoBehaviour {

	private Transform myTransform;


	public  float myShipSpeed;


	// Use this for initialization
	void Start () {

		myTransform = this.GetComponent <Transform> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		myTransform.position = new Vector3 ((myTransform.position.x + (0.1f * myShipSpeed*Time.deltaTime)) ,myTransform.position.y ,myTransform.position.z );

	}
}