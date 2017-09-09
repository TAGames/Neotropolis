/*************************************************************
* Bewegungsscript für den Mond                               * 
*************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMovement : MonoBehaviour {

	private Transform myTransform;

	public  float moonSpeed = 1; 

	// Use this for initialization
	void Start () {
		
		myTransform = this.GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myTransform.position = new Vector3 ((myTransform.position.x + (0.1f * moonSpeed*Time.deltaTime)) ,myTransform.position.y ,myTransform.position.z );
		
	}
}
