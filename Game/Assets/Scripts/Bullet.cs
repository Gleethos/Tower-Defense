using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	float desapwnTime = 2;
	//int Health = FindObjectOfType; 

	Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}

	public void SetVelocityVectors (float x, float y, float magnitude){
	
		velocity = new Vector3 (x* (Time.deltaTime / 2f), y*(Time.deltaTime / 2f), 0f) * magnitude; 

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (velocity);
		desapwnTime -= 1 * Time.deltaTime;

		if (desapwnTime <= 0) {
			Destroy (gameObject);
		}



	}

	/*public void OnTriggerEnter2D(Collider2D collider){
		
		Health--;

		if (Health == 0) {
			Destroy (collider.gameObject);
		}
	
		

		Destroy (gameObject);

	}*/

}