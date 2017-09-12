using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Card : MonoBehaviour {

	public string cardName;
	public Sprite picture; 
	public enum Rarity {Common, Rar, Epic, Legendary};
	public enum Edition {Normal, Special};
	public Rarity rarity;
	public Edition edition; 
	public int cardId; 


	public Card (string name, string rar, string edi, int id){
		cardName = name;
		switch (rar) {
		case "Common":
			rarity = Rarity.Common;
			break;
		case "Rar":
			rarity = Rarity.Rar;
			break;
		case "Epic":
			rarity = Rarity.Epic;
			break;
		case "Legendary":
			rarity = Rarity.Legendary;
			break;



		}


		switch (edi) {
		case "Normal":
			edition = Edition.Normal;
			break;

		case "Special":
			edition = Edition.Special;
			break;

		}

		cardId = id;
		picture = Resources.Load<Sprite> ("Sprites/City/Cards/" + cardName);


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
