using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlure : MonoBehaviour {

	Light mylight;
	public float startInt;
	public float endInt; 
	float timer=0f; 
	public float whenToChange=3f;
	// Use this for initialization
	void Start () {
		mylight = this.gameObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (timer > whenToChange){
			mylight.intensity = Random.Range (startInt, endInt);
			timer = 0f;
		}
		timer += Time.deltaTime; 

	}
}
