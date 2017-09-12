using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardsBib : MonoBehaviour {

	public List<Card> cardCollection;





	// Use this for initialization
	void Start () {
		cardCollection.Add (new Card ("Pepe", "Rar", "Normal", 0001));
		cardCollection.Add (new Card ("Pepe", "Rar", "Special", 0002));
		cardCollection.Add (new Card ("Alex", "Common", "Normal", 0003));
		cardCollection.Add (new Card ("Alex", "Common", "Special", 0004));
		cardCollection.Add (new Card ("Thomas", "Legendary", "Normal", 0005));
		cardCollection.Add (new Card ("Thomas", "Legendary", "Special", 0006));

		for (int i = 1; i<3; i++) {
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

		Debug.Log (rndEdition);
		Debug.Log (rndRarity);

		foreach (Card bla in cardCollection) {
			Debug.Log (bla.cardId);
		}

		if (rndEdition == 9) {
			pickList = cardCollection.FindAll( x => x.edition == Card.Edition.Special);
		}
		else {
			pickList = cardCollection.FindAll( x => x.edition == Card.Edition.Normal);
		}

		switch (rndRarity) {
		case (0-70):
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Common);
			break;
		case (70-90):
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Rar);
			break;
		case (91-98):
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Epic);
			break;
		case (99-100):
			pickList = pickList.FindAll (x => x.rarity == Card.Rarity.Legendary);
			break;
		}

		foreach (Card bla in pickList) {
			Debug.Log (bla.cardId);
		}

		finalCard = pickList[Random.Range(0, pickList.Count)];
		Debug.Log (finalCard.cardId + finalCard.cardName + finalCard.rarity +finalCard.edition);

		return finalCard;

	}









	}
