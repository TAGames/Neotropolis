using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SlotGame : MonoBehaviour {

	public GameObject[] myPlayStones; 
	public Sprite[] slotSprites;
	public  PlayerWallet wallet; 
	public int bet;
	public int minBet; 
	public int winMultiFour = 10; 
	public int winMultiTree = 1; 
	public GameObject betString;
	public GameObject walletString; 
	public Sprite startSprite;

	void Start(){
		betString.GetComponent<Text> ().text = "test"; 


	}


	void OnTriggerEnter2D(Collider2D player){
		foreach (GameObject go in myPlayStones) {
			go.GetComponent<Image> ().sprite = startSprite;

		}


		wallet = player.gameObject.GetComponent<PlayerWallet> ();
		bet= 0; 
		Debug.Log ("AHSJHAJ");

	}



	public void betInc (){
		if ((bet + minBet) <= wallet.credits) {
			bet += minBet; 
		}



	} 

	public void betDec (){
		if ((bet - minBet) >= 0) {
			bet -= minBet; 
		}

	} 



	public void PlayGame (){

		if (bet <= wallet.credits && (bet != 0)) {

			int sameCount = 0;
			int bestCount = 0;
			foreach (GameObject go in myPlayStones) {
				go.GetComponent<Image> ().sprite = slotSprites [Random.Range (0, slotSprites.Length)];

			}

			foreach (Sprite spri in slotSprites) {
				foreach (GameObject go in myPlayStones) {
					if (spri == go.GetComponent<Image> ().sprite) {
						sameCount++; 
					} 
				}
				if (sameCount > bestCount) {
					bestCount = sameCount;

				}
				sameCount = 0; 
			}

			Debug.Log (bestCount);

			switch (bestCount) {
			case 1: 
				wallet.credits -= bet;
				break; 
			case 2: 
				wallet.credits -= bet;
				break; 
			case 3:
				wallet.credits += bet * winMultiTree;
				break;
			case 4:
				wallet.credits += bet * winMultiFour; 
				break;



			}



			sameCount = 0;
			bestCount = 0; 

		}
	}

	void OnTriggerStay2D(Collider2D player){
		betString.GetComponent<Text> ().text = bet.ToString(); 
		walletString.GetComponent<Text> ().text = wallet.credits.ToString(); 
	}
		


	}

