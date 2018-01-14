using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret_Placement : MonoBehaviour {
	private int choosen = 0;
	public GameObject Turm1;
	public GameObject Turm2;
	public GameObject Turm3;
	private float x = 0f;
	private float y = 0f;
	public int balance = 6;
	public int score = 0;



	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		

		//Gold HUD 
		Text goldText;
		GameObject goldHUD = GameObject.Find ("GoldVariable");
		goldText = goldHUD.GetComponent<Text> ();
		goldText.text = "Gold: " + balance;

		//Score HUD
		Text scoreText;
		GameObject scoreHUD = GameObject.Find ("ScoreVariable");
		scoreText = scoreHUD.GetComponent<Text> ();
		scoreText.text = "Score: " + score;

		//Locate curser
		Vector3 position= Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//Hot keys
		if (Input.GetKeyDown ("1")) {
			
			//Debug.Log ("Eins");
			choosen = 1;

		
		}else if (Input.GetKeyDown ("2")) {

			//Debug.Log ("Zwei");
			choosen = 2;

		
		}else if (Input.GetKeyDown ("3")) {
		
			//Debug.Log ("Drei");
			choosen = 3;

		}

		//reset
		if(Input.GetMouseButtonDown(1) && choosen != 0 ){
			choosen = 0;
			//Debug.Log ("Choosen is" + choosen);
		}

		//Placement
		//Checking viable x/y position without base/road
		// 1 = AS Turm 2 = Stampfi 3 = Granata
		if (position.x > -9f && position.x < 11f && position.y > -18f && position.y < 1.5f) {
			
				if (choosen == 1 && Input.GetMouseButtonDown (0) && balance > 0) {

					//Debug.Log ("Position X: " + x + ", Position Y: " + y);
					Instantiate (Turm1, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance--;
					choosen = 0;


				} else if (choosen == 2 && Input.GetMouseButtonDown (0) && balance > 1) {

					Instantiate (Turm2, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance -= 2;
					choosen = 0;
		
				} else if (choosen == 3 && Input.GetMouseButtonDown (0) && balance > 2) {

					Instantiate (Turm3, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance -= 3; 
					choosen = 0;
		
				}

		}

	}
}

