using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	bool mouseIsDown;
	float mouseAnchorX;
	float mouseAnchorY;


	[SerializeField]
	private float cameraSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		checkInput ();
	}


	private void checkInput()
	{

		if(Input.GetKey(KeyCode.W))
		{transform.Translate (Vector3.up * cameraSpeed * Time.deltaTime);}

		if(Input.GetKey(KeyCode.A))
		{transform.Translate (Vector3.left * cameraSpeed * Time.deltaTime);}

		if(Input.GetKey(KeyCode.S))
		{transform.Translate (Vector3.down * cameraSpeed * Time.deltaTime);}

		if(Input.GetKey(KeyCode.D))
		{transform.Translate (Vector3.right * cameraSpeed * Time.deltaTime);}

	
		if(Input.GetMouseButton(2))
		{Vector3 position = Input.mousePosition;
		 if (mouseIsDown == false) {mouseIsDown = true;	mouseAnchorX = position.x;mouseAnchorY = position.y;} 
							  else {float dragVectorX = mouseAnchorX - position.x;
									float dragVectorY = mouseAnchorY - position.y;
									GameObject.Find ("Main Camera").transform.position 
									= new Vector3(GameObject.Find ("Main Camera").transform.position.x+(dragVectorX)/100, GameObject.Find ("Main Camera").transform.position.y+(dragVectorY)/100, -10);
									mouseAnchorX = position.x;
									mouseAnchorY = position.y;
									print ("dragVectorX:"+dragVectorX+"; dragVectorY:"+dragVectorY);}
		 }else{mouseIsDown = false;}


	}


}
