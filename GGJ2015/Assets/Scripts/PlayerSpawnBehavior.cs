using UnityEngine;
using System.Collections;

public class PlayerSpawnBehavior : MonoBehaviour {

	public GameObject spawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ResetLevel()
	{
		transform.position = spawnPoint.transform.position;
	}
}
