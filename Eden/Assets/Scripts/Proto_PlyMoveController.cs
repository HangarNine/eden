using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto_PlyMoveController : MonoBehaviour {

    public int moveSpeed;
    private bool facingRight = true;
    public int jumpPower;
    private float moveX;
    private float moveY;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        //Control Reading
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Animation

        //Direction
        if (moveX < 0.0f && facingRight)
        {
            FlipPlayer();
        }else if (moveX > 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}
