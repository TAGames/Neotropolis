using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetKey(KeyCode.T))
            {
                Interact();
            }
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetKey(KeyCode.T))
            {
                Interact();
            }
        }
    }


    public virtual void Interact()
    {
        Debug.Log("Interact!");
    }
}
