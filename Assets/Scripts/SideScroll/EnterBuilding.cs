// Script, zum entern von Gebäuden (Wand verschwindet mit collidern, neue Kollider die drinne sind, tauchen auf 
// Script am Hauptkollider anbringen (also Parent) 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour {


	[Tooltip("Das GameObject, was verschwinden soll, wenn man interagiert (Die Wand)")]
	public GameObject goDeactivate;
	[Tooltip("Das GameObject, was aktiviert werden soll (leeres GO mit neuen Collidern und neuer Logik")]
	public GameObject goActivate; 
	private bool switcher = true; 
	private bool inTrigger = false; 
	// Use this for initialization
	void Start () {
		goDeactivate.SetActive (switcher); 
		goActivate.SetActive (!switcher); 


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && (inTrigger == true)) {
			switcher = !switcher; 

			goDeactivate.SetActive (switcher); 
			goActivate.SetActive (!switcher); 

		}
	}



	void OnTriggerEnter2D(Collider2D other){
		inTrigger = true;

}

	void OnTriggerExit2D(Collider2D other){
		inTrigger = false; 
	}

}
