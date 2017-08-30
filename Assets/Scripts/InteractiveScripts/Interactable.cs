using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    bool oneTimeOnly = true;

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (oneTimeOnly)
                {
                    StartCoroutine(BlockInteraction());
                    Interact();
                    oneTimeOnly = false;
                }
                
            }
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
    }
    IEnumerator BlockInteraction()
    {
        yield return new WaitForSeconds(2);
        oneTimeOnly = true;
    }

    public virtual void Interact()
    {
        Debug.Log("Interact!");
    }
}
