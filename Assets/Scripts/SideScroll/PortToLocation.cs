// Telepotiert den Spieler (wenn er sich im Trigger befindet und F drückt) zur Position newPosition

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortToLocation : MonoBehaviour {
    
    private GameObject thePlayer;
    private bool inTrigger = false;
    private bool switcher = false;

    [Header("Die Position wo hingeportet werden soll")]
    public Vector3 newPosition; 

	
	// Update is called once per frame
	void Update () {

        if (inTrigger && Input.GetKeyDown(KeyCode.F) && !switcher)
        {
         
            thePlayer.transform.position = newPosition;
          
           
        }
  
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        thePlayer = collision.gameObject;

        inTrigger = true; 
    }

 

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false; 
    }
}
