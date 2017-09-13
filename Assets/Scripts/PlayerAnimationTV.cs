/***************************************
* Animationssteuerung für den Spieler  *
***************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTV : MonoBehaviour {


	private Animator newAnimator; 
	private Transform newTransform;
	private bool triggercheck = false;





	//Hier checken wir ob es eine Kollision gibt, als Parameter für "e" (interaktion mit Objekt Animation)
	void OnTriggerStay2D( Collider2D col) {
		if (col.gameObject.tag == "PlayerInteract") {
			this.triggercheck = true; 

		}

	}

	/********************************************************************************
	 * In dieser Methode schauen wir uns den Input des Spielers und auch Grounded an* 
	 * und wählen abhängig davon einen "States" aus, damit wir die verschiedenen    *
	 * Animationen aufrufen können               									*
     *******************************************************************************/
	private void AnimationHandler (Animator animator, Transform transform)
	{

		if (Input.GetKeyDown(KeyCode.E) && (this.triggercheck == true)) {
			animator.SetInteger ("States", 4);
		}

		//Solange ich fliege, 3
		/*else if (!controller.GetGrounded) {
			animator.SetInteger ("States", 3);
		} */
		//Wenn Grounded und D, 1
		else if (Input.GetAxis("Horizontal") > 0) {
			animator.SetInteger ("States", 1);
		}  
		//Wenn Grounded und A, 2
		else if (Input.GetAxis ("Horizontal") < 0) {
			animator.SetInteger ("States", 2);
		} 
		// Wenn grounded und E, 4

		//Wenn nichts von oben, 0
		else {
			animator.SetInteger ("States", 0);
		}


	}


	// Use this for initialization
	void Start () {
		newTransform = GetComponent<Transform> ();
		newAnimator = GetComponent <Animator> (); 

	}
	

	void Update () {


		AnimationHandler (newAnimator, newTransform);


		this.triggercheck = false; 


	}
}
