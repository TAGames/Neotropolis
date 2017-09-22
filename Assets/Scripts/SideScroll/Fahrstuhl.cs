using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fahrstuhl : MonoBehaviour {

	private GameObject player; 

	[Tooltip("Speed des Fahrstuhls")]
	public float elevatorSpeed = 1f; 
	private bool inTrigger = false; 
	private bool eleStart = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && (inTrigger == true)) {
			eleStart = true; 

			player.GetComponent<BoxCollider2D> ().enabled = false; 

			player.GetComponent<PlayerPlatformerController> ().enabled = false; 

		}

	}

	void OnTriggerEnter2D(Collider2D other){
		player =  other.gameObject; 
		inTrigger = true; 
	}

	void FixedUpdate(){

		if (eleStart){
			
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f ,transform.position.z );

		}
	}

	void OnTriggerExit2D(Collider2D other){
		inTrigger = false; 
	}
}
