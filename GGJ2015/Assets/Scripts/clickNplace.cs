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
		
		//instantiate the demo level
		Vector3 startPos = new Vector3(-541.4097f, -171.6246f, 0.0f);
		//allows object to determine if the game is in edit mode for self removal on right click
		GameObject yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = 567.597f;
		startPos.y = 88.07888f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x =476f;
		startPos.y = 13f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = -323.8196f;
		startPos.y = 124.9292f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = 134f;
		startPos.y = -177f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = -432.6147f;
		startPos.y = -18.96079f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = 376f;
		startPos.y = -87f;
		yop = (GameObject)(Instantiate(gameobject,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = 572f;
		startPos.y = 141f;
		yop = (GameObject)(Instantiate(goal,startPos,Quaternion.identity));
		yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
		
		startPos.x = -536f;
		startPos.y = 90f;
		yop = (GameObject)(Instantiate(spawn,startPos,Quaternion.identity));
//		yop.GetComponent<Spawner>().editCanvas = editCanvas;
		
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
			else if(State == States.Goal)
			{
				//allows object to determine if the game is in edit mode for self removal on right click
				GameObject yop = (GameObject)(Instantiate(goal,mousepos,Quaternion.identity));
				yop.GetComponent<CheckValidSpawn>().editCan = editCanvas;
			}
			else if(State == States.Player)
			{
				//no need to activate deleting, since there can only be one at a time anyway
				GameObject yop = (GameObject)(Instantiate(spawn,mousepos,Quaternion.identity));
//				yop.GetComponent<Spawner>().editCanvas = editCanvas;
			}
		}
	
	}
	
	//////////////////////////////
	public void ChangeActiveState(string newState)
	{
		if(newState == "Platform")
		{
			State = States.Floor;
		}
		else if(newState == "Goal")
		{
			State = States.Goal;
		}
		else if(newState == "Spawn")
		{
			State = States.Player;
		}
	}
	
	//////////////////////////////
	public void ChangeActiveState()
	{
		this.enabled = !this.enabled;
	}
}
