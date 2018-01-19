using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

	public int Health = 10;

	void Update () {
		//Health HUD 
		Text healthText;
		GameObject healthHUD = GameObject.Find ("LebenVariable");
		healthText = healthHUD.GetComponent<Text> ();
		healthText.text = "Leben:\t" + Health;

		if (Health <= 0) {
			//Debug.Log ("Game Over");
			//GAME OVER
			Text overText;
			GameObject overHUD = GameObject.Find ("WinLoose");
			overText = overHUD.GetComponent<Text> ();
			overText.text = "DEFEAT !";
		}
	}
	
	public void OnCollisionEnter2D(Collision2D collider){
		
		if(collider.gameObject.tag == ("Enemy")) {
			Health--;
			//Debug.Log ("Health:" + Health);
		}
	}
}
