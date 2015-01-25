using UnityEngine;
using System.Collections;

public class ChangeCanvasActive : MonoBehaviour {

	void Start()
	{
//		if(gameObject.name == "Play Canvas")
//			ChangeActiveState();
	}
	
	public void ChangeActiveState()
	{
		Debug.Log("changing active state of" + this.ToString());
		gameObject.SetActive(!gameObject.activeSelf);
	}
}
