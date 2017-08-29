using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SlotGame : MonoBehaviour {

	public GameObject[] myPlayStones; 
	public Sprite[] slotSprites;

	public void PlayGame (){

		int sameCount=0;
		int bestCount=0;
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
		sameCount = 0;
		bestCount = 0; 
	}

}
