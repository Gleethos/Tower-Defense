﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	float desapwnTime = 4;
	//int Health = FindObjectOfType; 

	Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}

	public void SetVelocityVectors (float x, float y, float magnitude){

		//how fast are u
		velocity = new Vector3 (x* (Time.deltaTime / 2f), y*(Time.deltaTime / 2f), 0f) * magnitude; 

	}
	
	// Update is called once per frame
	void Update () {

		//position update
		transform.Translate (velocity);

		//Despawning behavior
		desapwnTime -= 1 * Time.deltaTime;

		if (desapwnTime <= 0) {
			Destroy (gameObject);
		}
	



	}

	public void OnCollisionEnter2D(Collision2D collider){
		Destroy (this.gameObject);

	}



}