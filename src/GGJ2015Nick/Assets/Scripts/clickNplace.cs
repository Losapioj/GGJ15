using UnityEngine;
using System.Collections;

public class clickNplace : MonoBehaviour {
	public GameObject gameobject;
	public GameObject spawn;
	public GameObject goal; 
	enum States
	{
		Player,
		Goal,
		Floor,
	};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		States State = States.Floor;

		if (Input.GetKey (KeyCode.B)) 
		{
			if (State == States.Floor)
			{
				State = States.Goal;
			}
			if (State == States.Goal)
			{
				State = States.Player;
			}
			if (State == States.Player)
			{
				State = States.Floor;
			}
				}



		var mpos = Input.mousePosition;
		//mpos.x *= -1;
		//mpos.y *= -1;
		mpos.z = - transform.position.z;


		if (Input.GetMouseButtonDown (0))
		{
			//RaycastHit2D sit = Physics2D.Raycast(mpos, -Vector2.up);
			//if (sit.collider != null)
			//{
			//	Debug.Log(" "+sit.point.x);
			//}

			Vector3 mousepos = Camera.main.ScreenToWorldPoint(mpos);
			//Collider2D hitCollider = Physics2D.OverlapPoint(mousepos);

			Debug.Log ("mouse position x: " +mpos.x +"y: " +mpos.y +"z: " +mpos.z);




/*			Ray spot = Camera.main.ScreenPointToRay(mpos);
			mpos.z = -10;

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(ray);
			}

			if (Physics.Raycast(spot))
			{
				var tap = Instantiate(gameobject,transform.position,Quaternion.identity);
			//placement.position = mpos.position;
			}
			//Debug.Log(spot);
			Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePositionInWorld.z=-10;*/
			//var pat = Instantiate(gameobject,transform.position,Quaternion.identity);`
			if (State == States.Floor)
			{
				var yop = Instantiate(gameobject,mousepos,Quaternion.identity);
			}
			if(State == States.Goal)
			{
				var yop = Instantiate(goal,mousepos,Quaternion.identity);
			}
			if(State == States.Player)
			{
				var yop = Instantiate(spawn,mousepos,Quaternion.identity);
			}
				}
	
	}
}
