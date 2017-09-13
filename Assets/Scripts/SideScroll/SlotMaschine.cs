/*************************************************************
* Aktiviert das Canvas beim Eintreten in den Collider        * 
*************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SlotMaschine : MonoBehaviour {
	private bool inTrigger = false;
	public GameObject myObject; 
	bool myBool = true; 

	// Use this for initialization
	void Start () {
		myObject.SetActive (false);

	}


	void Update (){
		if (Input.GetKeyDown (KeyCode.F) && inTrigger) {
			{

				myObject.SetActive (myBool);}
			myBool = !myBool; 
		}
	}

	void OnTriggerStay2D(Collider2D player){
		
		inTrigger = true;

	}

	void OnTriggerExit2D(Collider2D player){

		inTrigger = false;
		myBool = false;
		myObject.SetActive (myBool);

	}



}
