using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float walkSpeedMod = 5.0f;
	public float jumpForceMod = 1.0f;

	public KeyCode jumpKeyDefault = KeyCode.Space;
	
	public KeyCode jumpKeyOne = KeyCode.W;
	public KeyCode jumpKeyTwo = KeyCode.UpArrow;
	public KeyCode rightKeyOne = KeyCode.D;
	public KeyCode rightKeyTwo = KeyCode.RightArrow;
	public KeyCode leftKeyOne = KeyCode.A;
	public KeyCode leftKeyTwo = KeyCode.LeftArrow;
	
	private bool moveLeft = false;
	private bool moveRight = false;
	private bool jump = false;
	private bool canJump = false;
	
	Animator anim;
	bool facingRight = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/////////////////////////////////////////////
	void FixedUpdate()
	{	
		//restrict rotation
		transform.rotation = Quaternion.identity;
		
		
		CheckMoveKeys();
		RemoveConflictingMoves();
		MovePlayer();
		
		if(moveLeft)
		{
			anim.SetBool("Walk", true);
			if(facingRight)
				FlipFacing();
		}
		else if(moveRight)
		{
			anim.SetBool("Walk", true);
			if(!facingRight)
				FlipFacing();
		}
		else
		{
			anim.SetBool("Walk", false);
		}
	}
	
	/////////////////////////////////////////////
	void CheckMoveKeys()
	{
		moveLeft = moveRight = jump = false;
	
		if( Input.GetKey(jumpKeyDefault) || 
			Input.GetKey(jumpKeyOne) || 
			Input.GetKey(jumpKeyTwo) )
		{
			jump = true;
		} 
		if( Input.GetKey(rightKeyOne) || 
		    Input.GetKey(rightKeyTwo) )
		{
			moveRight = true;
		}
		if( Input.GetKey(leftKeyOne) || 
		    Input.GetKey(leftKeyTwo) )
		{
			moveLeft = true;
		}
	}
	
	/////////////////////////////////////////////
	void RemoveConflictingMoves()
	{
		if(jump && !canJump)
		{
			jump = false;
		}		
		if(moveLeft && moveRight)
		{
			moveLeft = moveRight = false;
		}
	}
	
	/////////////////////////////////////////////
	void MovePlayer(bool reverseMove = false)
	{
		float mod = walkSpeedMod * Time.deltaTime;
		if(reverseMove)
		{
			mod *= -1;
		}
		
		
		if(moveLeft)
			transform.Translate(Vector3.left * mod);
		else if(moveRight)
			transform.Translate(Vector3.right * mod);
		if(jump)
		{
			Debug.Log("Jumping!");
			rigidbody2D.AddForce(Vector2.up * jumpForceMod);
			canJump = false;
			anim.SetBool("OnGround", false);
		}
	}
	
	/////////////////////////////////////////////
	void FlipFacing()
	{
		facingRight = !facingRight;
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;
	}
	
	/////////////////////////////////////////////
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Platform")
		{
//			Debug.Log("collided with platform");
			canJump = true;
			anim.SetBool("OnGround", true);
		}
	}
}







