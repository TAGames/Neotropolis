using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTopView : MonoBehaviour {

    public bool canWalk = true;
    public float maxSpeed = 10f;
    Rigidbody2D rb2D;
    Animator anim;
    bool facingRight = true;
    bool facingDown = true;
	// Use this for initialization
	void Start () {
        rb2D = transform.GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}
    void Move()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        if (canWalk)
        {
            //anim.SetFloat("Speed", Mathf.Abs(moveH));
            rb2D.velocity = new Vector2(moveH * maxSpeed, rb2D.velocity.y);
            rb2D.velocity = new Vector2(rb2D.velocity.x, moveV * maxSpeed);

            //if (moveH > 0 && !facingRight)
                //FlipH();
            //else if (moveH < 0 && facingRight)
                //FlipH();
        }
    }
    void FlipH()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
