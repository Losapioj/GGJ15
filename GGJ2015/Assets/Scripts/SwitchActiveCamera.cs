using UnityEngine;
using System.Collections;

public class SwitchActiveCamera : MonoBehaviour {

	public Camera playCam;
	public Camera editCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ToPlayCam()
	{
		playCam.enabled = true;
		editCam.enabled = false;
	}
	public void toEditCam()
	{
		editCam.enabled = true;
		playCam.enabled = false;
	}
}
