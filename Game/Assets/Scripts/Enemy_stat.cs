using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stat : MonoBehaviour {
	public int Health = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D collider){

		Health--;

		if (Health == 0) {
			Destroy (collider.gameObject);
		}




	}


}
