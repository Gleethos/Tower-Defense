using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiv : MonoBehaviour {
	//After granate hit enemies, this script start
	public float desapwnTime = 0.5f;
	//int Health = FindObjectOfType; 



	// Use this for initialization
	void Start () {

	}




	// Update is called once per frame
	void Update () {

		//Despawn Behavior
		desapwnTime -= 1 * Time.deltaTime;

		if (desapwnTime <= 0) {
			Destroy (gameObject);
		}




	}
}
