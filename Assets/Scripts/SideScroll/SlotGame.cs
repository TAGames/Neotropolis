/*
* Script was das gesammte SlotGame händelt                              
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SlotGame : MonoBehaviour {
	
	[Tooltip("Die teile die wechseln sollen")]
	public GameObject[] myPlayStones; 
	public Sprite[] slotSprites;
	public  PlayerWallet wallet; 
	public int bet;
	public int minBet; 
	public int winMultiFour  = 10; 
	public int winMultiTree = 1; 
	public GameObject betString;
	public GameObject walletString; 
	public Sprite startSprite;
	public Button startButton; 
	public int selectorCount=5;
	public float switchKeyWaiter = 1f; 
	public Text outPutText; 
	 






	void Start(){
		betString.GetComponent<Text> ().text = "test"; 


	}


	void OnTriggerEnter2D(Collider2D player){
		foreach (GameObject go in myPlayStones) {
			go.GetComponent<Image> ().sprite = startSprite;
			outPutText.text = "";

		}


		wallet = player.gameObject.GetComponent<PlayerWallet> ();
		bet= 0; 


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




	IEnumerator StoneSelector()
	{
		if (bet <= wallet.credits && (bet != 0)) {

			startButton.interactable = false;

			for (int i = 1; i < selectorCount; i++) {
				foreach (GameObject go in myPlayStones) {
					go.GetComponent<Image> ().sprite = slotSprites [Random.Range (0, slotSprites.Length)];

				}
				yield return new WaitForSeconds (switchKeyWaiter);
			}



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
				outPutText.text =  "\n"+"Verloren:     "+"-"+bet.ToString()+outPutText.text ;
				break; 
			case 2: 
				wallet.credits -= bet;
				outPutText.text = "\n"+ "Verloren:     "+"-"+bet.ToString()+outPutText.text +"\n";
				break; 
			case 3:
				wallet.credits += bet * winMultiTree;
				outPutText.text = "\n"+"Gewonnen: "+"+"+(bet*winMultiTree).ToString()+outPutText.text + "\n";
				break;
			case 4:
				wallet.credits += bet * winMultiFour; 
				outPutText.text = "\n"+"Gewonnen: "+"+"+(bet*winMultiFour).ToString()+outPutText.text + "\n";
				break;



			}



			sameCount = 0;
			bestCount = 0; 

		} else {
			outPutText.text =  "\n"+"Keine Credits"+outPutText.text +"\n";
		}

		startButton.interactable = true;
	}

	public void PlayGame (){


		StartCoroutine(StoneSelector());


	}

	void OnTriggerStay2D(Collider2D player){
		betString.GetComponent<Text> ().text = bet.ToString(); 
		walletString.GetComponent<Text> ().text = wallet.credits.ToString(); 


	}
		


	}

