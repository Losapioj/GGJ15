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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckMoveKeys();
		RemoveConflictingMoves();
		MovePlayer();
		
		//restrict rotation
		transform.rotation = Quaternion.identity;
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
		}
	}
	
	/////////////////////////////////////////////
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Platform")
		{
//			Debug.Log("collided with platform");
			canJump = true;
		}
	}
}







