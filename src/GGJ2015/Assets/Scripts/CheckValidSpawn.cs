using UnityEngine;
using System.Collections;

public class CheckValidSpawn : MonoBehaviour {

	public Rect validArea;
	
	public Canvas editCan;
	// Use this for initialization
	void Start () {
		checkValidSpawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void checkValidSpawn()
	{
		if(validArea.xMin > transform.position.x)
			Destroy(gameObject);
		else if(validArea.xMax < transform.position.x)
			Destroy(gameObject);
		else if(validArea.yMin > transform.position.y)
			Destroy(gameObject);
		else if(validArea.yMax < transform.position.y)
			Destroy(gameObject);
	}
	
	void OnMouseOver()
	{
		if(Input.GetMouseButton(1) && editCan.gameObject.activeSelf)
			Destroy(gameObject);
	}
}
