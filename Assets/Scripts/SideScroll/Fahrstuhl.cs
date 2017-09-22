using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fahrstuhl : MonoBehaviour {

	private GameObject player; 

	[Tooltip("Speed des Fahrstuhls")]
	public float elevatorSpeed = 1f; 
	[Tooltip("Wie weit der Fahrstuhl fährt in float")]
	public float travelDistance = 10f;
	private bool inTrigger = false; 
	private bool eleStart = false; 
	private Vector3 startPosition;
	public bool eleSwitch = false;
	public Vector3 endPosition;
	// Use this for initialization
	void Start () {

		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && (inTrigger == true)) {
			eleStart = true; 
			eleSwitch = !eleSwitch;


		}

	}

	void OnTriggerEnter2D(Collider2D other){
		player =  other.gameObject; 
		inTrigger = true; 
		player.transform.SetParent (this.transform);
	}

	void LateUpdate(){

		if (eleSwitch && Mathf.Abs (transform.position.y - startPosition.y) < travelDistance) {
			
			if (eleStart) {
				
				
				transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f*elevatorSpeed*Time.deltaTime, transform.position.z);
			

			}
		}
		else if (!eleSwitch && Mathf.Abs (transform.position.y - endPosition.y) < travelDistance) {

			if (eleStart) {
				

				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.1f*elevatorSpeed*Time.deltaTime, transform.position.z);
			

			}
	}
	}

	void OnTriggerExit2D(Collider2D other){
		inTrigger = false; 
		player.transform.SetParent (null);
	}
}
