using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorSwitcher : MonoBehaviour {

	private float timer = 0.0f; 
	public float switchTime = 2.0f; 
	private Light myLight;

	// Use this for initialization
	void Start () {
		myLight = this.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= switchTime) {

			Color newColor = new Color (Random.value, Random.value, Random.value, 1.0f);

			myLight.color = newColor;

			timer = 0; 
		}
	}
}
