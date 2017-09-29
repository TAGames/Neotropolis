using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class CardsBib : MonoBehaviour {

	public List<Card> cardCollection = new List<Card>();




	// Use this for initialization
	void Start () {
		cardCollection.Add (new Card ("Pepe","ultra lol", "Rar", "Normal", 0001));
		cardCollection.Add (new Card ("Pepe","ultra lol", "Rar", "Special", 0002));
		cardCollection.Add (new Card ("Alex", "ultra lol","Common", "Normal", 0003));
		cardCollection.Add (new Card ("Alex", "ultra lol","Common", "Special", 0004));
		cardCollection.Add (new Card ("Thomas", "ultra lol","Legendary", "Normal", 0005));
		cardCollection.Add (new Card ("Thomas", "ultra lol","Legendary", "Special", 0006));


		for (int i = 1; i<2; i++) {
			pickRandomCard ();
		}




		}



	public Card findCardWithIndex(int index){
		Card myCard = null;

		foreach (Card card in cardCollection){
			if (card.cardId == index) {
				myCard = card;
			} 
		}

		return myCard;

	}



	public Card pickRandomCard (){
		Card finalCard;
		int rndRarity = Random.Range (0, 100);

		int rndEdition = Random.Range (0, 10);
	 

 

		List <Card> pickList = cardCollection;



		
		

		if (rndEdition == 9) {
			pickList = cardCollection.FindAll( x => x.edition == Card.Edition.Special);
			

		}
		else {
			pickList = cardCollection.FindAll( x => x.edition == Card.Edition.Normal);
			
		}

		if (rndRarity < 71) {
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Common);
		} else if (rndRarity < 90) {
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Rar);
		} else if (rndRarity > 98) {
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Epic);
		} else {
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Legendary);
		}


		

		finalCard = pickList[Random.Range(0, pickList.Count)];
		

		return finalCard;

	}









	}
