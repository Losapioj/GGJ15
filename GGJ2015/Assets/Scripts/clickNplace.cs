using UnityEngine;
using System.Collections;

public class clickNplace : MonoBehaviour {
	public GameObject gameobject;
	public GameObject spawn;
	public GameObject goal;
	
	public Canvas editCanvas;
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
				//allows object to determine if the game is in edit mode for self removal on right click
				GameObject yop = (GameObject)(Instantiate(gameobject,mousepos,Quaternion.identity));
				yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
			}
			if(State == States.Goal)
			{
				//allows object to determine if the game is in edit mode for self removal on right click
				GameObject yop = (GameObject)(Instantiate(goal,mousepos,Quaternion.identity));
				yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
			}
			if(State == States.Player)
			{
				//no need to activate deleting, since there can only be one at a time anyway
				Instantiate(spawn,mousepos,Quaternion.identity);
			}
		}
	
	}
	
	//////////////////////////////
	public void ChangeActiveState()
	{
		this.enabled = !this.enabled;
	}
}
