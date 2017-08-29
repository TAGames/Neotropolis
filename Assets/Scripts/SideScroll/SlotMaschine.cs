using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMaschine : MonoBehaviour {

	public GameObject myObject; 
	bool myBool = false; 
	// Use this for initialization
	void Start () {
		myObject.SetActive (myBool);

	}
	

	void OnTriggerStay2D(Collider2D player){

		if(Input.GetKeyDown(KeyCode.F)){
			myBool = !myBool; 
			myObject.SetActive (myBool);}
			

	}

	void OnTriggerExit2D(Collider2D player){
		myBool = false;
		myObject.SetActive (myBool);

	}



}
