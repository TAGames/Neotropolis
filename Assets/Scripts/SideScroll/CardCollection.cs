// Die Aktuelle CardCollection des Spielers 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class CardCollection : MonoBehaviour {

	public List <Card> collection = new List<Card>();

	[Tooltip("Die Canvas, die die Collection darstellen soll")]
	public GameObject myCollectionCanvas; 
	public GameObject cardPicture;
	public GameObject cardInfoText; 
	public GameObject cardName;
	private int spriteIndex = 0;
	private bool activator = true;



	// Use this for initialization
	void Start () {
		myCollectionCanvas.SetActive (false);
	

		collection.Add (new Card ("Pepe", "lol", "Rar", "Normal", 0001));
		collection.Add (new Card ("Pepe", "ultra lol", "Rar", "Special", 0002));
		collection.Add (new Card ("Alex", "ultra lol", "Common", "Normal", 0003));
		collection.Add (new Card ("Alex", "ultra lol", "Common", "Special", 0004));
		collection.Add (new Card ("Thomas", "ultra lol", "Legendary", "Normal", 0005));
		collection.Add (new Card ("Thomas", "ultra lol", "Legendary", "Special", 0006));


		cardPicture.GetComponent<Image> ().sprite = collection [spriteIndex].picture;
		cardName.GetComponent<Text> ().text = collection [spriteIndex].cardName;
		cardInfoText.GetComponent<Text> ().text = collection [spriteIndex].cardInfo;


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.C) ){
			myCollectionCanvas.SetActive(activator); 
			activator = !activator; 
		}
			
	}


	public void nextSprite(){
		if ((spriteIndex + 1) >= collection.Count) {
			spriteIndex = 0;
		} else
			spriteIndex += 1; 

		cardPicture.GetComponent<Image> ().sprite = collection [spriteIndex].picture;
		cardName.GetComponent<Text> ().text = collection [spriteIndex].cardName;
		cardInfoText.GetComponent<Text> ().text = collection [spriteIndex].cardInfo;
	}

	public void beforeSprite(){
		if ((spriteIndex - 1) < 0) {
			spriteIndex = (collection.Count - 1);
		} else
			spriteIndex -= 1; 

		cardPicture.GetComponent<Image> ().sprite = collection [spriteIndex].picture;
		cardName.GetComponent<Text> ().text = collection [spriteIndex].cardName;
		cardInfoText.GetComponent<Text> ().text = collection [spriteIndex].cardInfo;
	}
}
