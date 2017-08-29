using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetButton("Fire1"))
            {
                Interact();
            }
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetButton("Fire1"))
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
