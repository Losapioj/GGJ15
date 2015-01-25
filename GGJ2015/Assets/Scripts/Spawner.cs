using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public bool isBeingCreated;

	public GameObject player;
	private Object currentPlayer;
	
	// Use this for initialization
	void Start () {
		isBeingCreated = true;
		GameObject[] otherSpawns = GameObject.FindGameObjectsWithTag(gameObject.tag);
		foreach(GameObject spawn in otherSpawns)
		{
			if(!spawn.GetComponent<Spawner>().isBeingCreated)
			{
				Destroy(spawn);
			}
		}
		isBeingCreated = false;
	}
	
	public void SpawnPlayer()
	{
		currentPlayer = Instantiate(player, transform.position, Quaternion.identity);
	}
	public void RespawnPlayer()
	{
		Destroy(currentPlayer);
		SpawnPlayer();
	}
}
