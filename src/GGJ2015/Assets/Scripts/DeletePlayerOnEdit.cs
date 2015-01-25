using UnityEngine;
using System.Collections;

public class DeletePlayerOnEdit : MonoBehaviour {

	public Canvas playCanvas;
	
	void Start()
	{
		Canvas[] all = Canvas.FindObjectsOfType<Canvas>();
		foreach(Canvas c in all)
		{
			Debug.Log("Checking Canvas Found");
			if(c.name == "Play Canvas")
			{
				Debug.Log("Found Play Canvas");
				playCanvas = c;
			}
		}
	}
	
	void Update()
	{
		if(!playCanvas.gameObject.activeSelf)
			Destroy(gameObject);
	}
	
}
