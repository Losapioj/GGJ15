using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

	public GameObject victorySprite;
	
	void OnTriggerEnter2D(Collider2D col)
	{
//		Debug.Log("Hit Goal");
		if(GameObject.FindGameObjectsWithTag("VictoryScreen").GetLength(0) == 0)
		{
			Instantiate(victorySprite);
		}
	}
}
