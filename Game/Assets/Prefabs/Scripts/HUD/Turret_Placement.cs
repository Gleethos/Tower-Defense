﻿using System.Collections;
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
	public int balance = 30;
	public int score = 0;

    GameObject dummyTurret;

    bool itemAttached = false;

    // Use this for initialization
    void Start () {


	}

	// Update is called once per frame
	void Update () {

		checkInput ();

        //Gold HUD 
        Text goldText;
		GameObject goldHUD = GameObject.Find ("GoldVariable");
		goldText = goldHUD.GetComponent<Text> ();
		goldText.text = "Gold: \t\t" + balance;

		//Score HUD
		Text scoreText;
		GameObject scoreHUD = GameObject.Find ("ScoreVariable");
		scoreText = scoreHUD.GetComponent<Text> ();
		scoreText.text = "Score: \t" + score;

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
			
				if (choosen == 1 && Input.GetMouseButtonDown (0) && balance > 4) {

					//Debug.Log ("Position X: " + x + ", Position Y: " + y);
					Instantiate (Turm1, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance -= 5;
					choosen = 0;


				} else if (choosen == 2 && Input.GetMouseButtonDown (0) && balance > 9) {

					Instantiate (Turm2, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance -= 10;
					choosen = 0;
		
				} else if (choosen == 3 && Input.GetMouseButtonDown (0) && balance > 14) {

					Instantiate (Turm3, new Vector3 (position.x, position.y, 0f), Quaternion.identity);
					balance -= 15; 
					choosen = 0;
		
				}

		}




	}




    public void setChoosen(int newChoosen)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        choosen = newChoosen;
        print("Mouse position X:" + Input.mousePosition.x + "; Mouse position Y:" + Input.mousePosition.y + "; ");
        if (choosen == 1) { dummyTurret = Instantiate(Turm1); }
        if (choosen == 2) { dummyTurret = Instantiate(Turm2); }
        if (choosen == 3) { dummyTurret = Instantiate(Turm3); }

        dummyTurret.transform.position = new Vector3((position.x), (position.y), 2);
        itemAttached = true;
    }


    private void checkInput()//Checks if item is attached and if this is the case: moves dummyTurret!
    {if (itemAttached)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0))
             { itemAttached = false; print("Item deattached!"); Destroy(dummyTurret);}
        else
            {
                dummyTurret.transform.position = new Vector3((position.x), (position.y), 2);
                print("Mouse position X:" + Input.mousePosition.x + "; Mouse position Y:" + Input.mousePosition.y + "; ");
            }
        }
        

    }


}

