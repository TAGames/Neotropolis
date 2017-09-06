using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTopView : MonoBehaviour {

    public bool canWalk = true;
    public float speed = 1;
    Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
        rb2D = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}
    void Move()
    {
        if (canWalk)
        {
            if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //rb2D.transform.position = new Vector2(rb2D.transform.position.x, rb2D.transform.position.y * Input.GetAxisRaw("Vertical") * speed);
            }
        }
    }
}
