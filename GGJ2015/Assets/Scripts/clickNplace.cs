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
	
	States State;
	// Use this for initialization
	void Start () {
		State = States.Floor;
	}
	
	// Update is called once per frame
	void Update () {

		

		if (Input.GetKeyDown (KeyCode.B)) 
		{
			Debug.Log ("Switching state to...");
			if (State == States.Floor)
			{
				Debug.Log ("...Goal");
				State = States.Goal;
			}
			else if (State == States.Goal)
			{
				Debug.Log ("...Player");
				State = States.Player;
			}
			else if (State == States.Player)
			{
				Debug.Log ("...Floor");
				State = States.Floor;
			}
		}



		var mpos = Input.mousePosition;
		//mpos.x *= -1;
		//mpos.y *= -1;
		mpos.z = - transform.position.z;

		if (Input.GetMouseButtonDown (0))
		{

			Vector3 mousepos = Camera.main.ScreenToWorldPoint(mpos);
			//Collider2D hitCollider = Physics2D.OverlapPoint(mousepos);

			Debug.Log ("mouse position x: " +mpos.x +"y: " +mpos.y +"z: " +mpos.z);

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
	
	//////////////////////////////
	public void ChangeActiveState()
	{
		this.enabled = !this.enabled;
	}
}
