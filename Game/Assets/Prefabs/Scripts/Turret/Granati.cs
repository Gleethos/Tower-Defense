﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granati : MonoBehaviour {
	public GameObject explosivBullet;
	float desapwnTime = 2;
	//int Health = FindObjectOfType; 

	Vector3 velocity;

	// Use this for initialization
	void Start () {

	}

	public void SetVelocityVectors (float x, float y, float magnitude){
		
		//How fast are u
		velocity = new Vector3 (x* (Time.deltaTime / 2f), y*(Time.deltaTime / 2f), 0f) * magnitude; 

	}

	// Update is called once per frame
	void Update () {

		//Position update
		transform.Translate (velocity);

		//Despawn behavior
		desapwnTime -= 1 * Time.deltaTime;

		if (desapwnTime <= 0) {
			Destroy (gameObject);
		}




	}

	public void OnCollisionEnter2D(Collision2D collider){
		
		GameObject explosivClone = Instantiate (explosivBullet, transform.position, Quaternion.identity);
		explosiv explosivScript = explosivClone.GetComponent <explosiv> ();

		Destroy (this.gameObject);

	}



}