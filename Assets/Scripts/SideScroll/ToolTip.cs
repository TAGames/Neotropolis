/*************************************************************
* Anzeigen eines Prefabs (ToolTip), wenn man Collider entert * 
*************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
	public GameObject myPrefab;
	private GameObject myObject;
	public string myString; 
	public int myFontSize = 7; 
	public Font myFont; 

	void OnTriggerEnter2D(Collider2D other){
		
		myObject=Instantiate(myPrefab); 
		myObject.transform.SetParent(transform);

		myObject.GetComponentInChildren<Text> ().text = myString;
		myObject.GetComponentInChildren<Text> ().fontSize = myFontSize;
		myObject.GetComponentInChildren<Text> ().font = myFont;
	}

	void OnTriggerExit2D(Collider2D other){
		Destroy (myObject);
	}
}
